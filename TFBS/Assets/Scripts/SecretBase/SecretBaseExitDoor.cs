using UnityEngine;
using System.Collections;

public class SecretBaseExitDoor : MonoBehaviour
{
    public static bool missionSelected;
    public static Scene mission;
    public static int objective;

    bool contact;
    bool display;
    public float displayTime;
    float time;

    void Start()
    {
        missionSelected = false;
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
            if (missionSelected)
            {
                Object.FindObjectOfType<PlayerDamage>().SaveHP();
                SceneManager.LoadScene(mission);
            }
            else
            {
                display = true;
                time = Time.time;
            }
        }
        if (display)
        {
            GUI.Label(new Rect((Screen.width / 2) + 500, Screen.height / 2 - 50, 250, 200), "You still haven't selected a mission");
        }
        if (time + displayTime < Time.time)
        {
            display = false;
        }
    }
}
