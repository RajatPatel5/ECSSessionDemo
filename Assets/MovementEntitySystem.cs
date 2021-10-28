using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Collections;

public class MovementEntitySystem : JobComponentSystem
{
    struct MoveEntityJob : IJobChunk
    {
        public Unity.Entities.ComponentTypeHandle<Translation> PositionTypeChunk;
        [ReadOnly]
        public Unity.Entities.ComponentTypeHandle<MovementData> MoveDataChunk;
        public float deltaTime;
        public void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
        {
            NativeArray<Translation> positions = chunk.GetNativeArray<Translation>(PositionTypeChunk);
            NativeArray<MovementData> moveDatas = chunk.GetNativeArray<MovementData>(MoveDataChunk);

            for (int i = 0; i < positions.Length; i++)
            {
                float3 currentPosition = positions[i].Value;
                float3 moveDirection = moveDatas[i].moveDirection;
                float moveSpeed = moveDatas[i].speed;

                currentPosition += moveDirection * moveSpeed * deltaTime;
                positions[i] = new Translation { Value = currentPosition };
            }
        }
    }

    private EntityQuery query;
    protected override void OnCreate()
    {
        query = this.GetEntityQuery(typeof(Translation), ComponentType.ReadOnly<MovementData>());
    }
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new MoveEntityJob();
        job.PositionTypeChunk = this.GetComponentTypeHandle<Translation>(false);
        job.MoveDataChunk = this.GetComponentTypeHandle<MovementData>(true);

        job.deltaTime = this.Time.DeltaTime;

        return job.Schedule(query, inputDeps);
    }
}
