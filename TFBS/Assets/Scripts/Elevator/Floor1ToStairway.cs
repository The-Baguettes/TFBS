using UnityEngine;
using System.Collections;

public class Floor1ToStairway : MonoBehaviour
{
    GameObject player;
    bool floor1;
   
    void Start()
    {
        player = GameObject.FindWithTag(Tags.Player);

        floor1 = SceneManager.LoadedScene == Scene.Stairway;
        if (SceneManager.PreviousScene() != Scene.MainMenu && SceneManager.PreviousScene() != Scene.Game &&
            SceneManager.PreviousScene() != Scene.SecretBase)
        {
            if (floor1)
            {
                //stairway position
                ChangePosition(-1.15f, 0.25f, 15.6f, 0f, 94f, 0f, 0.5f);
            }
            else
                if (SceneManager.PreviousScene() == Scene.Stairway && SceneManager.LoadedScene == Scene.Floor1)
                {
                    //floor1 position
                    ChangePosition(111.1736f, 0.2499999f, 9.682219f, 0f, -0.6988726f, 0f, 0.7152461f);
                }
        }
    }

    void ChangePosition(float x, float y, float z, float rotX, float rotY, float rotZ, float rotW)
    {
        player.transform.position = new Vector3(x, y, z);
        player.transform.rotation = new Quaternion(rotX, rotY, rotZ, rotW);
    }

    void OnTriggerEnter(Collider other)
    {
        if (PlayerBonus.hostageFollowing)
        {
            return;
        }
        if (other.tag == Tags.Player)
        {
            if (!floor1)
            {
                SceneManager.LoadScene(Scene.Stairway);
            }
            else
            {
                SceneManager.LoadScene(Scene.Floor1);
            }
        }
    }
}
