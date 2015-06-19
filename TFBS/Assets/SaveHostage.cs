using UnityEngine;
using System.Collections;

public class SaveHostage : MonoBehaviour
{
    bool saved;

    void Start()
    {
        saved = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.Hostage)
        {
            saved = true;
            other.gameObject.active = false;
            Missions.missionCompleted = true;
        }
    }

    void OnGUI()
    {
        if (saved)
        {
            GUI.Label(new Rect((Screen.width / 2) - 200, Screen.height / 2 - 100, 250, 200), "You saved the hostage, well done.");
        }
    }
}
