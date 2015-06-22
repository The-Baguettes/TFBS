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
            //mission 1 : vol de document
            case 3:
                PlayerMoney.Money += 70000;
                if (hud.enemyAlive())
                {
                    PlayerMoney.Money += 70000;
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
                        PlayerBonus.enableAssassinationMission = true;
                    }
                }
                PlayerBonus.shopEnable = true;
                break;
            //mission 2: sauvetage d'otage
            case 2:
                if (PlayerBonus.deadHostage && hud.noEnemy()) //if hostage dead: 30K compensation
                {
                    PlayerMoney.Money += 30000;
                }
                else
                {
                    if (PlayerBonus.doubleHostage) //if double save: full reward
                    {
                        PlayerMoney.Money += 270000;
                        PlayerBonus.noPrice = true;
                        PlayerBonus.shopEnable = true;
                        PlayerBonus.recruit = true;
                        PlayerBonus.enableAssassinationMission = true;
                    }
                    else
                    {
                        PlayerMoney.Money += 90000;//simple hostage
                        if (PlayerBonus.hardHostage) //extra for hard hostage
                        {
                            PlayerMoney.Money += 90000;
                            PlayerBonus.noPrice = true; //no loss for killing or buying items
                        }
                        else
                            PlayerBonus.recruit = true; //recruit a fighter
                    }
                }
                break;
                //mission 3: destruction de labo
            case 1:
                PlayerMoney.Money += 100000;
                PlayerMoney.useMoney(hud.EnemyDead * 2500);
                break;
                //mission 4
            case 4:
                PlayerMoney.Money += 60000;
                break;
                //mission 5
            case 5:
                PlayerMoney.Money += 90000;
                break;
                //mission 6
            case 6:
                PlayerMoney.Money += 150000;
                break;
            default:
                break;
        }
    }
}
