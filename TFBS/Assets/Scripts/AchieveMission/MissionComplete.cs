using UnityEngine;
using System.Threading;
using System.Collections;

public class MissionComplete : MonoBehaviour
{

    HUD hud;
    private bool contact;
    public bool given;

    void Start()
    {
        given = false;
        hud = GameObject.FindObjectOfType<HUD>();
        contact = false;
        Missions.missionCompleted = false;
    }

    void Update()
    {
        if (given)
        {
            given = false;
        }
    }

    void OnGUI()
    {
        if (contact)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 200, 30), "'F' to leave the building");
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (Missions.missionCompleted && !given)
                {
                    given = true;
                    reward();
                }
                SceneManager.LoadScene(Scene.SecretBase);
            }
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
            //mission 2: sauvetage d'otage
            case 2: if (PlayerBonus.deadHostage && hud.noEnemy()) //if hostage dead: 30K compensation
                {
                    PlayerMoney.addMoney(30000);
                }
                else
                {
                    if (PlayerBonus.doubleHostage) //if double save: full reward
                    {
                        PlayerMoney.addMoney(270000);
                        PlayerBonus.noPrice = true;
                        PlayerBonus.shopEnable = true;
                        PlayerBonus.recruit = true;
                    }
                    else
                    {
                        PlayerMoney.addMoney(90000);//simple hostage
                        if (PlayerBonus.hardHostage) //extra for hard hostage
                        {
                            PlayerMoney.addMoney(90000);
                            PlayerBonus.noPrice = true; //no loss for killing or buying items
                        }
                        else
                            PlayerBonus.recruit = true; //recruit a fighter
                    }
                }
                break;
                //mission 1: destruction de labo
            case 1: PlayerMoney.addMoney(100000);
                PlayerMoney.useMoney(hud.EnemyDead * 2500);
                break;
            default:
                break;
        }
    }
}
