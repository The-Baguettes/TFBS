using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Surveillance : MonoBehaviour {

    bool isPlayer;
    public GameObject GOCamera;
    List<GameObject> ListCamera;
    int compteur;
	void Start () {
        isPlayer = false;
        compteur = 0; 
        for (int i = 0; i < GOCamera.transform.childCount; i++)
        {
            ListCamera[i] = GOCamera.transform.GetChild(i).GetChild(0).gameObject;
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

	void Update () {       
       if(Input.GetKeyDown(KeyCode.F))
       {
           compteur += 1;
       }

	}
}
