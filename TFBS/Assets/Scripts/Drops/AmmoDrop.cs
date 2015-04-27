using UnityEngine;

public class AmmoDrop : DropBase
{
    override protected Color32 color { get { return Color.black; } }

    override protected void OnPickup()
    {
        firePlayer.magasine += 1;
    }
}
