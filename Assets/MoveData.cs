using System;
using Unity.Entities;
using Unity.Mathematics;

[Serializable]
public struct MoveData : IComponentData
{
    public float3 moveDirection;
    public float moveSpeed;
}
