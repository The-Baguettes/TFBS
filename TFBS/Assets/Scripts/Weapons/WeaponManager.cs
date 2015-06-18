using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : BaseComponent
{
    public BaseWeapon ActiveWeapon { get; protected set; }
    public BaseGun ActiveGun { get; protected set; }

    public List<BaseWeapon> Weapons { get; protected set; }

    public event EventHandler ActiveUsed;
    public event EventHandler SwitchedWeapon;

    protected void Awake()
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

            if (ActiveUsed != null)
                ActiveUsed();
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

        if (SwitchedWeapon != null)
            SwitchedWeapon();
    }
}
