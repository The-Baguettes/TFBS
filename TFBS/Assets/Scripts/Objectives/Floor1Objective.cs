using UnityEngine;

public class Floor1Objective : MonoBehaviour
{
    HUD hud;

    void Start()
    {
        //load from the editor
        if (Missions.objective == 0)
        {
            Missions.objective = 2;
        }

        hud = GameObject.FindObjectOfType<HUD>();
        if (Missions.objective == 1)
        {
            hud.SetObjective("Use the door next to the elevator");
        }
        else
            if (Missions.objective == 2)
            {
                hud.SetObjective("Save the hostage at this level.");
            }
            else
                if (Missions.objective == 3)
                {
                    hud.SetObjective("Take the elevator");
                }
                else
                {
                    hud.SetObjective(null);
                }
    }

    void Update()
    {
        if (Missions.missionCompleted)
        {
            hud.SetObjective("Mission completed \nfind a way to escape the building. Exit are at first floor.");
        }
    }

    /* MISSION 3 : vol de document
       MISSION 2 : sauvetage d'otages
       MISSION 1 : destruction d'une étage
     */
}
