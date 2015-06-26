using UnityEngine;

public class Floor1Objective : MonoBehaviour
{
    HUD hud;
    new public GameObject gameObject;

    void Start()
    {
        //load from the editor
        if (Missions.objective == 0)
        {
            Missions.objective = 5;
        }

        hud = GameObject.FindObjectOfType<HUD>();
        if (Missions.objective == 1 || Missions.objective == 6)
        {
            hud.SetObjective("Use the door next to the elevator");
        }
        else
            if (Missions.objective == 2)
            {
                hud.SetObjective("Save the hostage at this level.");
            }
            else
                if (Missions.objective == 3 || Missions.objective == 4)
                {
                    hud.SetObjective("Take the elevator");
                }
                else
                {
                    hud.SetObjective("Kill all the enemies at this floor");
                }
        if (Missions.objective != 2 || Missions.missionCompleted)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Missions.objective == 5 && hud.noEnemy())
            Missions.missionCompleted = true;

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
