using UnityEngine;
using System.Collections;

public class FireAlarm : MonoBehaviour
{
    bool contact;
    bool pressed;
    int time;
    new GameObject audio;

    void Start()
    {
        audio = GameObject.Find("AlarmSound");
        contact = false;
        pressed = false;
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
        if (!pressed && contact)
        {
            GUI.Label(new Rect((Screen.width / 2) - 150, Screen.height / 2 - 50, 250, 200), "Press 'F' to use the fire alarm");
            if (Input.GetKeyDown(KeyCode.F))
            {
                time = (int)Time.time;
                pressed = true;
                audio.GetComponent<AudioSource>().Play();
            }
        }
        if (PlayerBonus.scientistAlive && time + 35 > Time.time)
        {
            GUI.Label(new Rect((Screen.width / 2) - 200, Screen.height / 2 - 100, 250, 200), "You saved the scientist, well done.");
        }
    }

    void Update()
    {
        if (pressed && !PlayerBonus.scientistAlive)
        {
            if (time + 30 < Time.time)
            {
                //function that makes scientist disappear
                PlayerBonus.scientistAlive = true;
            }
        }
    }
}
