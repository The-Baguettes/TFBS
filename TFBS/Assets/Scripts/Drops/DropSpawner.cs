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
        InvokeRepeating("SpawnCube", 0f, 60f);
    }

    void SpawnCube()
    {
        Transform spawn = spawnPoints[random.Next(spawnPoints.Count)];

        // Don't spawn multiple drops in the same place
        if (spawn.childCount != 0)
            return;

        GameObject drop = GameObject.CreatePrimitive(PrimitiveType.Cube);
        drop.AddComponent(dropTypes[random.Next(dropTypes.Length)]);
        drop.transform.SetParent(spawn, false);
    }
}
