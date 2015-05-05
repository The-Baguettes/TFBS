using UnityEngine;
using System.Threading;
using System.Collections;

public class MissionComplete : MonoBehaviour
{

    HUD hud;
    private bool contact;
    private bool incompleteMessage;
    private float incompleteMessageCD;
    public static bool missionCompleted;

    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
        contact = false;
        incompleteMessage = false;
        missionCompleted = false;
    }

    void Update()
    {
        if (incompleteMessageCD + 4 < Time.time)
        {
            incompleteMessage = false;
        }
        if (!missionCompleted)
        {
            if (SecretBaseExitDoor.objective == 1 || SecretBaseExitDoor.objective == 2)
            {
                if (hud.noEnemy())
                {
                    missionCompleted = true;
                }
            }
        }
    }

    void OnGUI()
    {
        if (contact && !incompleteMessage)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 200, 30), "'F' to leave the building");
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (missionCompleted)
                {
                    SceneManager.LoadScene(Scene.SecretBase);
                }
                else
                {
                    contact = false;
                    incompleteMessage = true;
                    incompleteMessageCD = Time.time;
                }
            }
        }
        if (incompleteMessage)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 200, 100), "You still haven't completed the mission!");
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
