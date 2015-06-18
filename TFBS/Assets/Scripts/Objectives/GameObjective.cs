using UnityEngine;

public class GameObjective : MonoBehaviour
{
    HUD hud;

    void Start()
    {
        //load from the editor
        if (Missions.objective == 0)
        {
            Missions.objective = 3;
        }

        hud = GameObject.FindObjectOfType<HUD>();
        if (Missions.objective == 1)
        {
            hud.SetObjective("Destroy the laboratory using the stairway");
        }
        else
            if (Missions.objective == 2)
            {
                hud.SetObjective("Save the hostages at the first floor using the elevator");
            }
            else
                if (Missions.objective == 3)
                {
                    hud.SetObjective("Find the confidential information in the secret room at this floor");
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
        if (Missions.missionCompleted)
        {
            hud.SetObjective("Mission completed \nfind a way to escape the building");
        }
    }

    /* MISSION 3 : vol de document
       MISSION 2 : sauvetage d'otages
       MISSION 1 : destruction d'une étage
     */
}
