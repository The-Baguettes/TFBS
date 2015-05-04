using UnityEngine;

public class GameObjective : MonoBehaviour
{
    HUD hud;

    void Start()
    {
        //load from the editor
        if (SecretBaseExitDoor.objective == 0)
        {
            SecretBaseExitDoor.objective = 2;
        }

        hud = GameObject.FindObjectOfType<HUD>();
        if (SecretBaseExitDoor.objective == 1)
        {
            hud.SetObjective("Kill the enemies");
        }
        else
            if (SecretBaseExitDoor.objective == 2)
            {
                hud.SetObjective("Kill the enemies");
            }
            else
                if (SecretBaseExitDoor.objective == 3)
                {
                    hud.SetObjective("Find the confidential information in the secret room");
                }
                else
                {
                    hud.SetObjective(null);
                }
        //hud.SetObjective("Find the elevator");
    }

    /*
    void OnTriggerEnter(Collider checkpointcol)
    {
        if (checkpointcol.tag == Tags.Player)
            hud.SetObjective(null);
    }*/

    void Update()
    {
        if (MissionComplete.missionCompleted)
        {
            hud.SetObjective("Mission completed \nfind a way to escape");
        }
    }
}
