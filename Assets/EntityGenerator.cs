using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Mathematics;

public class EntityGenerator : MonoBehaviour
{
    public GameObject objectPrefab;
    public float3 objectPosition;
    public float objectScale;
    EntityManager entityManager;

    public float3 moveDirection;
    public float speed;
    private void Start()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        var objectEntity = GameObjectConversionUtility.ConvertGameObjectHierarchy(objectPrefab, new GameObjectConversionSettings(World.DefaultGameObjectInjectionWorld, GameObjectConversionUtility.ConversionFlags.AddEntityGUID));

        var spawnedEntity = entityManager.Instantiate(objectEntity);


        entityManager.SetComponentData(spawnedEntity, new Translation { Value = objectPosition });
        entityManager.AddComponentData(spawnedEntity, new Scale { Value = objectScale });
        entityManager.AddComponentData(spawnedEntity, new MovementData { moveDirection =  moveDirection, speed = speed});
    }
}
