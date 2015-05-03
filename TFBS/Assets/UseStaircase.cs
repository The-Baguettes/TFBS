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
            if (to == Scene.Game)
            {
                
            }
            if (to == Scene.Stairway)
            {
                
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
}
