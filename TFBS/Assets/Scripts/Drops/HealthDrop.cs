using UnityEngine;

public class HealthDrop : DropBase
{
    protected override void OnPickup()
    {
        playerHealth.currentHealth += 20;
    }
}
