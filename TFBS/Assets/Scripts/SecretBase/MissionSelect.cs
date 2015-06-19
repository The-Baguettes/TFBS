using UnityEngine;
using System.Collections;

public class MissionSelect : MonoBehaviour
{
    bool contact;
    bool displayConfirmation;
    float time;
    public float displayTime;
    public Canvas missionSelect;
    public string displayMessage;

    void Awake()
    {
        contact = false;
        missionSelect.enabled = false;
        displayConfirmation = false;
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

    void OnGUI()
    {
        if (contact)
        {
            if (missionSelect.enabled)
            {
                if (GUI.Button(new Rect(Screen.width - 200, Screen.height - 100, 100, 50), "Close", "button"))
                {
                    missionSelect.enabled = false;
                }
            }
            else
            {
                GUI.Label(new Rect((3 * Screen.width / 4) - 50, Screen.height / 2 - 50, 250, 200), "Press 'F' to open the " + displayMessage);
            }
        }
        else
            missionSelect.enabled = false;

        if (displayConfirmation)
        {
            GUI.Label(new Rect((3 * Screen.width / 4) - 50, Screen.height / 2 + 150, 250, 200), "Mission has been correctly selected");
        }
        if (time + displayTime < Time.time)
        {
            displayConfirmation = false;
        }
    }

    void Update()
    {
        if (contact && Input.GetKeyDown(KeyCode.F))
        {
            missionSelect.enabled = !missionSelect.enabled;
        }
    }

    public void MissionOne()
    {
        MissionSelected();
        Missions.objective = 1;
    }

    public void MissionTwo()
    {
        MissionSelected();
        Missions.objective = 2;
    }

    public void MissionThree()
    {
        MissionSelected();
        Missions.objective = 3;
    }

    public void MissionFour()
    {
        MissionSelected();
        Missions.objective = 4;
    }

    public void MissionFive()
    {
        MissionSelected();
        Missions.objective = 5;
    }

    public void MissionSix()
    {
        MissionSelected();
        Missions.objective = 6;
    }

    void MissionSelected()
    {
        Missions.missionSelected = true;
        missionSelect.enabled = false;
        displayConfirmation = true;
        time = Time.time;
    }
}
