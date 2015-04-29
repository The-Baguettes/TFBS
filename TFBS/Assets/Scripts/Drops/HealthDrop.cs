using UnityEngine;

public class HealthDrop : DropBase
{
    override protected Color32 color { get { return Color.green; } }

    override protected bool Pickup()
    {
        playerDamage.Heal(20);
        return true;
    }
}
