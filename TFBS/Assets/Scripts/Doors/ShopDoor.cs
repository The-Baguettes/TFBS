using UnityEngine;
using System.Collections;

public class ShopDoor : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(Scene.SecretBase);
    }
}
