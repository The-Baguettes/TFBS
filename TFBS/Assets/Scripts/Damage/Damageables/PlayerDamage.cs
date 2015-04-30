using UnityEngine;

public class PlayerDamage : BaseDamageable
{
    HUD hud;
 
    protected override void OnStart()
    {
        MaxHealthPoints = 200;
        HealthPoints = 150;

        hud = FindObjectOfType<HUD>();
    }

    protected override void OnDeath()
    {
        GameObject.FindWithTag(Tags.MainCamera).SetActive(false);
        hud.DeathCanvas.enabled = false;
    }

    protected override void OnTakeDamage()
    {
        if (HealthPoints < 50 && !hud.DeathCanvas.enabled)
        {
            hud.LifeText.color = Color.red;
            hud.DeathCanvas.enabled = true;
        }
    }
}
