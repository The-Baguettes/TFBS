using UnityEngine;

public class StairwayObjective : MonoBehaviour
{
    HUD hud;
    public GameObject gameObject;

    void Start()
    {
        //load from the editor
        if (Missions.objective == 0)
        {
            Missions.objective = 6;
        }

        hud = GameObject.FindObjectOfType<HUD>();
        if (Missions.objective == 1)
        {
            hud.SetObjective("Destroy the laboratory by placing 5 bombs on the blue spotlights \nthen find a room leading underground to trigger the explosion."
                + "\nOptional: Find the alarm to evacuate scientist \nfrom the building, then you have to wait a minute.");
        }
        else
            if (Missions.objective == 2 || Missions.objective == 5)
            {
                hud.SetObjective("Use the door next to the stairs");
            }
            else
                if (Missions.objective == 3 || Missions.objective == 4)
                {
                    hud.SetObjective("Go to first floor");
                }
                else
                {
                    hud.SetObjective("Kill all the enemies at this floor");
                }
        if (Missions.objective != 1 || Missions.missionCompleted)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Missions.objective == 6 && hud.noEnemy())
            Missions.missionCompleted = true;

        if (Missions.missionCompleted)
        {
            hud.SetObjective("Mission completed \nfind a way to escape the building. Exit are at first floor");
        }
    }

    /* MISSION 3 : vol de document
       MISSION 2 : sauvetage d'otages
       MISSION 1 : destruction d'une étage
     */
}
