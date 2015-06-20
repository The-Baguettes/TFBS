using UnityEngine;

public class UseElevator : MonoBehaviour
{
    GameObject player;
    bool contact;
    Canvas PauseCanvas;
    Canvas GameOverCanvas;
    public GameObject leftDoor;
    bool isClose;
    float leftDoorClosePosition;
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
        PauseCanvas = GameObject.Find("Pause").GetComponent<Canvas>();
        GameOverCanvas = GameObject.Find("Game Over").GetComponent<Canvas>();
        leftDoorClosePosition = leftDoor.transform.position.z;
        isClose = true;
        player = GameObject.FindWithTag(Tags.Player);

        if (SceneManager.PreviousScene() != Scene.MainMenu && SceneManager.PreviousScene() != Scene.Stairway &&
            SceneManager.PreviousScene() != Scene.SecretBase)
        {
            if (SceneManager.LoadedScene == Scene.Game)
            {
                ChangePosition(110.7403f, 0.2600501f, 16.77837f, 0f, -0.7216773f, 0f, 0.6922296f);
            }
            if (SceneManager.LoadedScene == Scene.Floor1)
            {
                ChangePosition(110.4f, 0.2600499f, 16.88f, 0f, -0.7071068f, 0f, 0.7071067f);
            }
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

    void OnGUI()
    {
        if (!PauseCanvas.enabled && !GameOverCanvas.enabled)
        {
            if (contact)
            {
                if (!isClose)
                {
                    return;
                }
                GUI.Label(new Rect((Screen.width * 3 / 4) - 25, Screen.height / 2 - 40, 250, 50), "Which floor do you want to go?");
                if (GUI.Button(new Rect((Screen.width * 3 / 4) - 25, Screen.height / 2, 150, 50), "1st Floor"))
                {
                    if (SceneManager.LoadedScene != Scene.Game)
                    {
                        Object.FindObjectOfType<PlayerDamage>().SaveHP();
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
                    if (SceneManager.LoadedScene != Scene.Floor1)
                    {
                        Object.FindObjectOfType<PlayerDamage>().SaveHP();
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

    void Update()
    {
        isClose = leftDoorClosePosition == leftDoor.transform.position.z;
    }

    void ChangePosition(float x, float y, float z, float rotX, float rotY, float rotZ, float rotW)
    {
        player.transform.position = new Vector3(x, y, z);
        player.transform.rotation = new Quaternion(rotX, rotY, rotZ, rotW);
    }
}
