using UnityEngine;
using System.Collections.Generic;

public class Medicine : MonoBehaviour
{
    GameObject Cube;
    List<Transform> spawnPoints;

    void Start()
    {
        spawnPoints = new List<Transform>();
        GetComponentsInChildren<Transform>(spawnPoints);
        spawnPoints.Remove(transform);

        SpawnCube();
    }

    void rotation(GameObject cube) // Allow the cube to rotate 
    {
        cube.transform.Rotate(cube.transform.position * Time.deltaTime * 2);
    }

    void SpawnCube()
    {            
        Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);        
        //Cube.tag = "Medecine";
        Cube.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
        // TODO: Create DropRotate class, and add as component to Cube
        // This way we don't need an Update here, so we don't need to store the Cube.
        // So we can spawn as many as we want.
    }

    void Update()
    {
        rotation(Cube);
    }
}
