using UnityEngine;

public class StairwayObjective : MonoBehaviour
{
    HUD hud;

    void Start()
    {
        //load from the editor
        if (Missions.objective == 0)
        {
            Missions.objective = 1;
        }

        hud = GameObject.FindObjectOfType<HUD>();
        if (Missions.objective == 1)
        {
            hud.SetObjective("Destroy the laboratory by placing 5 bombs on the blue spotlights \nthen find a room leading underground to trigger the explosion."
                + "\nOptional: Find the alarm to evacuate scientist \nfrom the building, then you have to wait a minute.");
        }
        else
            if (Missions.objective == 2)
            {
                hud.SetObjective("Use the door next to the stairs");
            }
            else
                if (Missions.objective == 3)
                {
                    hud.SetObjective("Go to level 0");
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
            hud.SetObjective("Mission completed \nfind a way to escape the building. Exit are at level 0");
        }
    }

    /* MISSION 3 : vol de document
       MISSION 2 : sauvetage d'otages
       MISSION 1 : destruction d'une étage
     */
}
