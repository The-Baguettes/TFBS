using UnityEngine;

public class EnemyHealth : MonoBehaviour
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
        Destroy(gameObject);
        //Death animation script here
    }
}
