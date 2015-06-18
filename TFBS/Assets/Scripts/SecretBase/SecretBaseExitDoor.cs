using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SecretBaseExitDoor : MonoBehaviour
{
    public Canvas map;
    bool contact;
    bool display;
    public float displayTime;
    float time;

    void Start()
    {
        map.enabled = false;
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
                map.enabled = true;
                Object.FindObjectOfType<PlayerDamage>().SaveHP();
            }
            else
            {
                display = true;
                time = Time.time;
            }
        }
        else
        {
            map.enabled = false;
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
