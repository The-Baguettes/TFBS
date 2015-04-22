using UnityEngine;
using System.Threading;
using System.Collections;

public class MissionComplete : MonoBehaviour {

    private bool contact;
    private bool missionCompleted;
    
    void Start()
    {
        contact = false;
        missionCompleted = false;
    }

    void Update()
    {
        //function that determine if the mission has been completed
    }
    

    void OnGUI()
    {
        if (contact)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 200, 30), "'F' to leave the building");
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (missionCompleted)
                {
                    //switch to mission completed scene
                }
                else
                {
                    contact = false;
                    GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 200, 30), "You still haven't completed the mission!");
                }
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
}
