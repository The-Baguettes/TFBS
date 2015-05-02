using UnityEngine;
using System.Collections;

public class GameObjective : MonoBehaviour {

    HUD hud;
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
        hud.Objective = "Find the elevator";
    }
    void OnTriggerEnter(Collider checkpointcol)
    {
        print(checkpointcol.tag);
        if (checkpointcol.tag == Tags.Player)
        {
            hud.Objective = "You Passed The Level";
        }
    }

}
