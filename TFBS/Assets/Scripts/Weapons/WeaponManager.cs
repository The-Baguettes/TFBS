using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon ActiveWeapon { get; protected set; }
    public Gun ActiveGun { get; protected set; }

    public List<Weapon> Weapons { get; protected set; }

    void Start()
    {
        Weapons = new List<Weapon>();
        GetComponentsInChildren<Weapon>(Weapons);

        for (int i = 0; i < Weapons.Count; i++)
            Weapons[i].gameObject.SetActive(false);
    }

    public void UseActive(Transform target = null)
    {
        if (ActiveWeapon != null)
            ActiveWeapon.Use(target);
    }

    public void SwitchToWeapon(int n)
    {
        if (n < 0 || n >= Weapons.Count)
            return;

        if (ActiveWeapon != null)
            ActiveWeapon.gameObject.SetActive(false);

        ActiveWeapon = Weapons[n];
        ActiveGun = ActiveWeapon as Gun;

        ActiveWeapon.gameObject.SetActive(true);
    }
}
