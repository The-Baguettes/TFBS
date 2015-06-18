using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Missions : MonoBehaviour
{
    public static bool missionSelected;
    public static Scene mission;
    public static int objective;
    public static bool missionCompleted;
    public string finishedMission;

    public Button button;
    public Button button1;
    public Button button2;

    void Start()
    {
        MissionSuccess();
        display();
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
        missionSelected = false;
        missionCompleted = false;
    }

    void display()
    {
        int i = 0;
        int n;
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
                default:
                    break;
            }
            i++;
        }
    }
}
