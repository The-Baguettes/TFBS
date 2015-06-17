using UnityEngine;
using System.Threading;
using System.Collections;

public class MissionComplete : MonoBehaviour
{

    HUD hud;
    private bool contact;
    private bool incompleteMessage;
    private float incompleteMessageCD;
    public bool given;

    void Start()
    {
        given = false;
        hud = GameObject.FindObjectOfType<HUD>();
        contact = false;
        incompleteMessage = false;
        Missions.missionCompleted = false;
    }

    void Update()
    {
        if (given)
        {
            given = false;
        }
        if (incompleteMessageCD + 4 < Time.time)
        {
            incompleteMessage = false;
        }
        if (!Missions.missionCompleted)
        {
            if (Missions.objective == 1 || Missions.objective == 2)
            {
                if (hud.noEnemy())
                {
                    Missions.missionCompleted = true;
                }
            }
        }
    }

    void OnGUI()
    {
        if (contact && !incompleteMessage)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 200, 30), "'F' to leave the building");
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (Missions.missionCompleted)
                {
                    if (!given)
                    {
                        given = true;
                        reward();
                    }
                    SceneManager.LoadScene(Scene.SecretBase);
                }
                else
                {
                    contact = false;
                    incompleteMessage = true;
                    incompleteMessageCD = Time.time;
                }
            }
        }
        if (incompleteMessage)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 200, 100), "You still haven't completed the mission!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.Player)
        {
            contact = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.Player)
        {
            contact = false;
        }
    }

    void reward()
    {
        //récompense de mission
        switch (Missions.objective)
        {
            //mission 3 : vol de document
            case 3: PlayerMoney.addMoney(70000);
                if (hud.enemyAlive())
                {
                    PlayerMoney.addMoney(70000);
                    PlayerBonus.noPrice = true;
                }
                else
                {
                    if (hud.EnemyDead < 3)
                    {
                        PlayerMoney.useMoney(20000);
                        PlayerBonus.halfPrice = true;
                    }
                    else
                        PlayerMoney.useMoney(2500 * hud.EnemyDead);
                    if (hud.noEnemy())
                    {
                        AssassinationMission.enable = true;
                    }
                }
                PlayerBonus.shopEnable = true;
                break;
            default:
                break;
        }
    }
}
