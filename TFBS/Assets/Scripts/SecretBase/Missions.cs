using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Missions : MonoBehaviour
{
    public static bool missionSelected;
    public static int objective;
    public static bool missionCompleted;
    public static string finishedMission;

    public Button button;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;

    void Start()
    {
        if (SceneManager.LoadedScene == Scene.SecretBase)
        {
            MissionSuccess();
            display();
        }
    }

    void MissionSuccess()
    {
        if (missionCompleted)
        {
            finishedMission += objective;
        }
        MissionReset();
    }

    void MissionReset()
    {
        missionCompleted = false;
    }

    void display()
    {
        int i = 0;
        int n;
        if (finishedMission == null)
        {
            return;
        }
        while (i < finishedMission.Length)
        {
            n = finishedMission[i];
            switch (n)
            {
                case '1': button.enabled = false;
                    button.GetComponentInChildren<Text>().text = "Success";
                    break;
                case '2': button1.enabled = false;
                    button1.GetComponentInChildren<Text>().text = "Success";
                    break;
                case '3': button2.enabled = false;
                    button2.GetComponentInChildren<Text>().text = "Success";
                    PlayerBonus.shopEnable = true;
                    break;
                case '4': button3.enabled = false;
                    button.GetComponentInChildren<Text>().text = "Success";
                    break;
                case '5': button4.enabled = false;
                    button.GetComponentInChildren<Text>().text = "Success";
                    break;
                case '6': button5.enabled = false;
                    button.GetComponentInChildren<Text>().text = "Success";
                    break;
                default:
                    break;
            }
            i++;
        }
    }
}
