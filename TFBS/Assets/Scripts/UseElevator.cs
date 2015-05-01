using UnityEngine;
using UnityEditor;
using System.Collections;

public class UseElevator : MonoBehaviour
{
    bool contact;
    Canvas PauseCanvas;
    public Scene firstFloor;
    public Scene secondFloor;
    //public Scene thirdFloor;


    void Start()
    {
        contact = false;
        PauseCanvas = GameObject.Find("PauseCanvas").GetComponent<Canvas>();
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
        if (!PauseCanvas.enabled)
        {
            if (contact)
            {
                GUI.Label(new Rect((Screen.width * 3 / 4) - 25, Screen.height / 2 - 40, 250, 50), "Which floor do you want to go?");
                if (GUI.Button(new Rect((Screen.width * 3 / 4) - 25, Screen.height / 2, 150, 50), "1st Floor") && Application.loadedLevel != 4)
                {
                    SceneManager.LoadScene(firstFloor);
                }
                if (GUI.Button(new Rect((Screen.width * 3 / 4) - 25, Screen.height / 2 + 60, 150, 50), "2nd Floor") && Application.loadedLevel != 5)
                {
                    SceneManager.LoadScene(secondFloor);
                }
                /*
                if (GUI.Button(new Rect((Screen.width * 3 / 4) - 25, Screen.height / 2 + 120, 150, 50), "3rd Floor") && EditorApplication.currentScene != thirdFloor.ToString())
                {
                    SceneManager.LoadScene(thirdFloor);
                }*/
            }
        }
    }
}
