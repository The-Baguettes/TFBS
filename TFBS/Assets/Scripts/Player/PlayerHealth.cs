using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;

    HUD hud;
 
    void Awake()
    {
        currentHealth = startingHealth;
        hud = FindObjectOfType<HUD>();
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

        if (currentHealth < 50)
        {
            hud.LifeText.color = Color.red;
            hud.DeathCanvas.enabled = true;
        }
    }
}
