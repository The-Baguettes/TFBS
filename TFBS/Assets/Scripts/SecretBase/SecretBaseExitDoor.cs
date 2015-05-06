using UnityEngine;
using System.Collections;

public class SecretBaseExitDoor : MonoBehaviour
{
    bool contact;
    bool display;
    public float displayTime;
    float time;

    void Start()
    {
        contact = false;
        display = false;
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
            if (Missions.missionSelected)
            {
                Object.FindObjectOfType<PlayerDamage>().SaveHP();
                SceneManager.LoadScene(Missions.mission);
            }
            else
            {
                display = true;
                time = Time.time;
            }
        }
        if (display)
        {
            GUI.Label(new Rect((3 * Screen.width / 4) + 50, Screen.height / 2 - 50, 250, 200), "You still haven't selected a mission");
        }
        if (time + displayTime < Time.time)
        {
            display = false;
        }
    }
}
