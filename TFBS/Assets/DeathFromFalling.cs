using UnityEngine;

public class DeathFromFalling : MonoBehaviour
{
    PlayerDamage playerDamage;

    void Start()
    {
        playerDamage = Object.FindObjectOfType<PlayerDamage>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.Player)
            playerDamage.Kill();
    }
}
