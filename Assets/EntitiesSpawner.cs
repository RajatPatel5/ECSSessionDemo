using System.Collections;
using Unity.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Rendering;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class EntitiesSpawner : MonoBehaviour
{
    // public RenderMesh renderMesh;

    // EntityManager entityManager;

    // void Start()
    // {
    //     // entityManager = World.Active.GetOrCreateSystem<EntityManager>();
    //     // entityManager = World.Active.EntityManager;

    //     var emptyEntity = entityManager.CreateEntity();

    //     var pos = new float3(1, 1, 1);
    //     var scale = 1;

    //     var spawnedEntity = entityManager.Instantiate(emptyEntity);


    //     entityManager.AddSharedComponentData(spawnedEntity, renderMesh);
    //     entityManager.AddComponentData(spawnedEntity, new Translation { Value = pos });
    //     entityManager.AddComponentData(spawnedEntity, new Scale { Value = scale });
    //     entityManager.AddComponentData(spawnedEntity, new Rotation { Value = quaternion.Euler(0, 0, 0) });
    // }

    public float3 entityMoveDirection;
    public float entityMoveSpeed;

    public GameObject entityPrefab;
    EntityManager entityManager;
    private void Start()
    {
        // entityManager = World.Active.GetOrCreateSystem<EntityManager>();
        // entityManager = World.Active.EntityManager;
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        var emptyGameObject = GameObjectConversionUtility.ConvertGameObjectHierarchy(entityPrefab, new GameObjectConversionSettings(World.DefaultGameObjectInjectionWorld, GameObjectConversionUtility.ConversionFlags.AddEntityGUID));

        var spawnedEntity = entityManager.Instantiate(emptyGameObject);
        
        var pos = new float3(1, 1, 1);
        var scale = 2;

        // var moveDirection = new float3(0, 0, 1);

        entityManager.SetComponentData(spawnedEntity, new Translation { Value = pos });
        entityManager.AddComponentData(spawnedEntity, new Scale { Value = scale });
        entityManager.AddComponentData(spawnedEntity, new Rotation { Value = quaternion.Euler(45, 45, 45) });
        entityManager.AddComponentData(spawnedEntity, new MoveData { moveDirection =  entityMoveDirection, moveSpeed = entityMoveSpeed});
    }
}
