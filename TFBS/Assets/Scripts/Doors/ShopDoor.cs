using UnityEngine;
using System.Collections;

public class ShopDoor : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag(Tags.Player);
    }

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(Scene.SecretBase);
    }
}
