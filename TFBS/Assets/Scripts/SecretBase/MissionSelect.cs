using UnityEngine;
using System.Collections;

public class MissionSelect : MonoBehaviour
{
    bool contact;
    bool displayConfirmation;
    float time;
    public float displayTime;
    Canvas missionSelect;
    public Scene sceneGame;

    void Start()
    {
        contact = false;
        missionSelect = GameObject.Find("MissionSelect").GetComponent<Canvas>();
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
                if (GUI.Button(new Rect(Screen.width -200, Screen.height - 100, 100, 50), "Close", "button"))
                {
                    missionSelect.enabled = false;
                }
            }
            else
            {
                GUI.Label(new Rect((Screen.width / 2) + 500, Screen.height / 2 - 50, 250, 200), "Press 'F' to open the mission selection window");
            }
        }

        if (displayConfirmation)
        {
            GUI.Label(new Rect((Screen.width / 2) + 500, Screen.height / 2 + 300, 250, 200), "Mission has been correctly selected");
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
        SecretBaseExitDoor.mission = sceneGame;
        SecretBaseExitDoor.objective = 1;
    }

    public void MissionTwo()
    {
        MissionSelected();
        SecretBaseExitDoor.mission = sceneGame;
        SecretBaseExitDoor.objective = 2;
    }

    public void MissionThree()
    {
        MissionSelected();
        SecretBaseExitDoor.mission = sceneGame;
        SecretBaseExitDoor.objective = 3;
    }

    void MissionSelected()
    {
        SecretBaseExitDoor.missionSelected = true;
        missionSelect.enabled = false;
        displayConfirmation = true;
        time = Time.time;
    }
}
