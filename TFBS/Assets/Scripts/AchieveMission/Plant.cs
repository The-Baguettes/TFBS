using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour
{
    bool contact;
    GameObject bomb;
    public string gameObjectName;
    public GameObject light;
    GameObject audio;

    void Start()
    {
        audio = GameObject.Find("AudioBomb");
        contact = false;
        bomb = GameObject.Find(gameObjectName);
        bomb.active = false;
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
        if (contact && !bomb.active)
        {
            GUI.Label(new Rect((Screen.width / 2) - 150, Screen.height / 2 - 50, 250, 200), "Press 'F' to plant a C4");
            if (Input.GetKeyDown(KeyCode.F))
            {
                bomb.active = true;
                light.GetComponent<Light>().enabled = false;
                audio.GetComponent<AudioSource>().Play();
            }
        }
    }
}
