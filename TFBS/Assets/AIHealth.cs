using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AIHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    // public Slider healthSlider;                                                                          


    void Awake()
    {
        currentHealth = startingHealth;
    }


    void Update()
    {
        Debug.Log("currentHealth");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Bullet(Clone)")
        {
            TakeDamage(20);

        }
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        Destroy(gameObject);
        //Game Over script here
    }
}