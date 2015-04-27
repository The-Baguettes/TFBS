using UnityEngine;

public class AmmoDrop : DropBase
{
    protected override void OnPickup()
    {
        firePlayer.magasine += 1;
    }
}
