using UnityEngine;
using System.Collections;

public class MissionSelect : MonoBehaviour
{
    bool contact;
    Canvas missionSelect;

    void Start()
    {
        contact = false;
        missionSelect = GameObject.Find("MissionSelect").GetComponent<Canvas>();
        missionSelect.enabled = false;
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
    }

    void Update()
    {
        if (contact && Input.GetKeyDown(KeyCode.F))
        {
            missionSelect.enabled = !missionSelect.enabled;
        }
    }
}
