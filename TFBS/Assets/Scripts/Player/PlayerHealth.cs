using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
 
    void Awake()
    {
        currentHealth = startingHealth;
    }

    void Update()
    {       
        if (Input.GetButtonDown("Die"))
            currentHealth = -1;        

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.Bullet)
            TakeDamage(20);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
    }
}
