using UnityEngine;
using System.Collections;

public class GameEnd : MonoBehaviour
{
    bool contact;

    void Start()
    {
        contact = false;
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
            GUI.Label(new Rect((Screen.width / 2) - 150, Screen.height / 2 - 50, 250, 200), "Press 'F' to put the briefcase");
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(Scene.Credit);
            }
        }
    }
}
