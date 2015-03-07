using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.Bullet)
            TakeDamage(20);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
            Death();
    }
    void Death()
    {
       // Destroy(gameObject);
       //Game Over script here
    }
}
