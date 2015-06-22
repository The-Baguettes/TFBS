using System;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    static readonly Type[] dropTypes = {
        typeof(AmmoDrop),
        typeof(HealthDrop),
    };
    static readonly System.Random random = new System.Random();

    List<Transform> spawnPoints;

    void Start()
    {
        spawnPoints = new List<Transform>();
        GetComponentsInChildren<Transform>(spawnPoints);
        spawnPoints.Remove(transform);

        // Call SpawnCube now (in 0), and then every 60 seconds
        InvokeRepeating("SpawnCube", 0, 60);
    }

    void SpawnCube()
    {
        Transform spawn = spawnPoints[random.Next(spawnPoints.Count)];

        // Don't spawn multiple drops in the same place
        if (spawn.childCount != 0)
            return;

        SpawnCube(spawn, dropTypes[random.Next(dropTypes.Length)], true);
    }

    public static void SpawnCube<T>(Transform position)
        where T : DropBase
    {
        SpawnCube(position, typeof(T), false);
    }

    static void SpawnCube(Transform position, Type dropType, bool randomDrop)
    {
        GameObject drop = GameObject.CreatePrimitive(PrimitiveType.Cube);
        drop.AddComponent(dropType);

        if (randomDrop)
            // Set as child and copy position
            drop.transform.SetParent(position, false);
        else
            drop.transform.position = position.position;
    }
}
