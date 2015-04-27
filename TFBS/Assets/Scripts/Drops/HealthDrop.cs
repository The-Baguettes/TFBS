using UnityEngine;

public class HealthDrop : DropBase
{
    override protected Color32 color { get { return Color.green; } }

    override protected void OnPickup()
    {
        playerHealth.currentHealth += 20;
    }
}
