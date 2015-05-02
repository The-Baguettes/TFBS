using UnityEngine;
using UnityEditor;
using System.Collections;

public class UseElevator : MonoBehaviour
{
    bool contact;
    Canvas PauseCanvas;
    Canvas GameOverCanvas;
    //public Scene firstLevel;
    //public Scene secondLevel;
    bool display;
    float displayCD;
    string level;
    public float displayTime;
    //public Scene thirdFloor;


    void Start()
    {
        level = "";
        displayCD = 0;
        display = false;
        contact = false;
        PauseCanvas = GameObject.Find("PauseCanvas").GetComponent<Canvas>();
        GameOverCanvas = GameObject.Find("GameOverCanvas").GetComponent<Canvas>();
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
        if (!PauseCanvas.enabled && !GameOverCanvas.enabled)
        {
            if (contact)
            {
                GUI.Label(new Rect((Screen.width * 3 / 4) - 25, Screen.height / 2 - 40, 250, 50), "Which floor do you want to go?");
                if (GUI.Button(new Rect((Screen.width * 3 / 4) - 25, Screen.height / 2, 150, 50), "1st Floor"))
                {
                    if (Application.loadedLevel != 3)
                    {
                        SceneManager.LoadScene(Scene.Game);
                    }
                    else
                    {
                        display = true;
                        level = "1st";
                        displayCD = Time.time;
                    }
                }
                if (GUI.Button(new Rect((Screen.width * 3 / 4) - 25, Screen.height / 2 + 60, 150, 50), "2nd Floor"))
                {
                    if (Application.loadedLevel != 4)
                    {
                        SceneManager.LoadScene(Scene.Floor1);
                    }
                    else
                    {
                        display = true;
                        level = "2nd";
                        displayCD = Time.time;
                    }
                }
                /*
                if (GUI.Button(new Rect((Screen.width * 3 / 4) - 25, Screen.height / 2 + 120, 150, 50), "3rd Floor") && EditorApplication.currentScene != thirdFloor.ToString())
                {
                    SceneManager.LoadScene(thirdFloor);
                }*/

                //display alert part
                if (display)
                {
                    GUI.Label(new Rect((Screen.width / 2) - 150, Screen.height / 2 - 50, 250, 200), "You already are in " + level + " Floor");
                }
                if (displayCD + displayTime < Time.time)
                {
                    display = false;
                }
            }
        }
    }
}
