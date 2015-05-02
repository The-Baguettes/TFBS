using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : BaseComponent
{
    public BaseWeapon ActiveWeapon { get; protected set; }
    public BaseGun ActiveGun { get; protected set; }

    public List<BaseWeapon> Weapons { get; protected set; }

    public event EventHandler OnUseActive;
    public event EventHandler OnWeaponSwitch;

    protected override void OnStart()
    {
        Weapons = new List<BaseWeapon>();
        GetComponentsInChildren<BaseWeapon>(Weapons);

        for (int i = 0; i < Weapons.Count; i++)
            Weapons[i].gameObject.SetActive(false);
    }

    public void UseActive(Transform target = null)
    {
        if (ActiveWeapon != null)
        {
            ActiveWeapon.Use(target);

            if (OnUseActive != null)
                OnUseActive();
        }
    }

    public void SwitchToWeapon(int n)
    {
        if (n < 0 || n >= Weapons.Count)
            return;

        if (ActiveWeapon != null)
            ActiveWeapon.gameObject.SetActive(false);

        ActiveWeapon = Weapons[n];
        ActiveGun = ActiveWeapon as BaseGun;

        ActiveWeapon.gameObject.SetActive(true);

        if (OnWeaponSwitch != null)
            OnWeaponSwitch();
    }
}
