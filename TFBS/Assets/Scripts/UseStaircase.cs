using UnityEngine;
using System.Collections;

public class UseStaircase : MonoBehaviour
{
    GameObject player;
    public Scene to;

    void Start()
    {
        player = GameObject.FindWithTag(Tags.Player);
        if (SceneManager.PreviousScene() != Scene.MainMenu)
        {
            if (SceneManager.LoadedScene == Scene.Stairway)
            {
                ChangePosition(2.53f, 0.3f, -3.09f, 0f, 0f, 0f, 0f);
            }
            if (SceneManager.LoadedScene == Scene.Game)
            {
                ChangePosition(110.2734f, 0.9393333f, 9.426224f, 0f, -0.7194812f, 0, 0.694512f);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.Player)
        {
            SceneManager.LoadScene(to);
        }
    }

    void ChangePosition(float x, float y, float z, float rotX, float rotY, float rotZ, float rotW)
    {
        player.transform.position = new Vector3(x, y, z);
        player.transform.rotation = new Quaternion(rotX, rotY, rotZ, rotW);
    }
}
