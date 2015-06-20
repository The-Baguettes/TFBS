using UnityEngine;

public class GameObjective : MonoBehaviour
{
    HUD hud;

    void Start()
    {
        //load from the editor
        if (Missions.objective == 0)
        {
            Missions.objective = 4;
        }

        hud = GameObject.FindObjectOfType<HUD>();
        if (Missions.objective == 1 || Missions.objective == 6)
        {
            hud.SetObjective("Use the stairway");
        }
        else
            if (Missions.objective == 2 || Missions.objective == 5)
            {
                hud.SetObjective("Use the elevator");
            }
            else
                if (Missions.objective == 3)
                {
                    hud.SetObjective("Find the confidential information in the secret room at this floor");
                }
                else
                {
                    hud.SetObjective("Kill all the enemies at this floor");
                }
    }

    void Update()
    {
        if (Missions.objective == 4 && hud.noEnemy())
        {
            Missions.missionCompleted = true;
        }

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
