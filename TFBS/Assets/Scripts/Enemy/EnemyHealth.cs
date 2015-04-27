using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;

    EnemyAI ai;

    void Awake()
    {
        currentHealth = startingHealth;
        ai = GetComponent<EnemyAI>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.Bullet)
        {
            TakeDamage(20);
            ai.OnTakeDamage();
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Death();
    }

    void Death()
    {
        DropSpawner.SpawnCube<AmmoDrop>(transform);
        Destroy(gameObject);
        //Death animation script here
    }
}
