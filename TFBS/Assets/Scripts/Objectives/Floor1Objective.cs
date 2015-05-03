using UnityEngine;
using System.Collections;

public class Floor1Objective : MonoBehaviour {

    HUD hud;
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
        hud.Objective = "Eliminates all the ennemies";
    }
    void OnTriggerEnter(Collider checkpointcol)
    {
        //print(checkpointcol.tag);
        if (checkpointcol.tag == Tags.Player)
        {
            hud.Objective = "You Passed The Level";
        }
    }

}
