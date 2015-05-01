using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    HUD hud;
    void Start() 
    {
        hud = GameObject.FindObjectOfType<HUD>();
        hud.Objective = "Find the secret room";
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
