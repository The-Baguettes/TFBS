using UnityEngine;
using System.Collections;

public class DeathFromFalling : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.Player)
        {
            //kill the player
        }
    }
}
