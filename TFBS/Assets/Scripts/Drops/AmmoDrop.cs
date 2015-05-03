using UnityEngine;

public class AmmoDrop : DropBase
{
    override protected Color32 color { get { return Color.black; } }

    HUD hud;

    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
    }

    override protected bool Pickup()
    {
        if (weaponManager.ActiveGun == null)
            return false;

        weaponManager.ActiveGun.MagazineCount += 1;
        hud.playerWeaponManager_OnUseActive();
        return true;
    }
}
