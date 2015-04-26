using UnityEngine;
using System.Collections;

public class Medicine : MonoBehaviour
{
    public GameObject Life1;
    public GameObject Life2;
    int random;
    GameObject Cube;

    void Start()
    {
        random = Random.Range(1, 3);    
        Cube = Random_generate();
        Cube.tag = "Medecine";
    }

    void rotation(GameObject cube) // Allow the cube to rotate 
    {
        cube.transform.Rotate(cube.transform.position * Time.deltaTime * 2);
    }

    GameObject Random_generate()
    {            
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);        
        if(random == 1)
        {
            cube.transform.position = Life1.transform.position;
        }
        if(random == 2)
        {
            cube.transform.position = Life2.transform.position;
        }
        return cube;
    }

   

    void Update()
    {
        rotation(Cube);
    }
}
