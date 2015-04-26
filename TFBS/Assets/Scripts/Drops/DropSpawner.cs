using UnityEngine;
using System.Collections.Generic;

public class DropSpawner : MonoBehaviour
{
    PlayerHealth playerHealth;
    List<Transform> spawnPoints;

    void Start()
    {
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();

        spawnPoints = new List<Transform>();
        GetComponentsInChildren<Transform>(spawnPoints);
        spawnPoints.Remove(transform);

        // Call SpawnCube now (in 0), and then every 60 seconds
        InvokeRepeating("SpawnCube", 0f, 60f);
    }

    void SpawnCube()
    {
        Transform spawn = spawnPoints[Random.Range(0, spawnPoints.Count)];

        // Don't spawn multiple drops in the same place
        if (spawn.childCount != 0)
            return;

        // TODO: Add different kinds of drops
        GameObject drop = GameObject.CreatePrimitive(PrimitiveType.Cube);
        drop.AddComponent<Drop>().PlayerHealth = playerHealth;
        drop.transform.SetParent(spawn, false);
    }
}
