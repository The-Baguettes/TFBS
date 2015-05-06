using UnityEngine;
using System.Collections;

public class MissionThreeCompleted : MonoBehaviour
{
    bool contact;
    bool bookPresent;
    public GameObject book;

    void Start()
    {
        contact = false;
        bookPresent = true;
    }

    void OnGUI()
    {
        if (contact && bookPresent)
        {
            GUI.Label(new Rect((Screen.width / 2) - 150, Screen.height / 2 - 50, 250, 200), "Press 'F' to take the book");
        }
    }

    void Update()
    {
        if (contact && Input.GetKeyDown(KeyCode.F))
        {
            GameObject.Destroy(book);
            bookPresent = false;
            Missions.missionCompleted = true;
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
