using UnityEngine;

public class AmmoDrop : DropBase
{
    override protected Color32 color { get { return Color.black; } }

    override protected bool Pickup()
    {
        if (weaponManager.ActiveGun == null)
            return false;

        weaponManager.ActiveGun.MagazineCount += 1;
        return true;
    }
}
