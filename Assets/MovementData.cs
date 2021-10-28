using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
public struct MovementData : IComponentData
{
    public float3 moveDirection;

    public float speed;
}
