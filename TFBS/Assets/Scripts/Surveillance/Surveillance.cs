using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Surveillance : MonoBehaviour
{

    bool isPlayer;
    public GameObject GOCamera;
    public Camera Main;
    List<Camera> ListCamera;
    int compteur;
    int last;

    void Awake()
    {
        isPlayer = false;
        compteur = 0;
        ListCamera = new List<Camera>();
        GOCamera.GetComponentsInChildren<Camera>(ListCamera);
    }

    void Start()
    {
        for (int i = 0; i < ListCamera.Count; i++)
        {
            ListCamera[i].enabled = false;
            ListCamera[i].depth = Main.depth + 1;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.Player)
            isPlayer = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == Tags.Player)
            isPlayer = false;
    }

    void Update()
    {
        if (!isPlayer)
            return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            ListCamera[compteur].enabled = false;
            compteur = (compteur + 1) % ListCamera.Count;
            ListCamera[compteur].enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            ListCamera[compteur].enabled = false;
        }

    }
}
