using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon ActiveWeapon { get; protected set; }
    public Gun ActiveGun { get; protected set; }

    public List<Weapon> Weapons { get; protected set; }

    float lastUseTime = -1;

    void Start()
    {
        Weapons = new List<Weapon>();
        GetComponentsInChildren<Weapon>(Weapons);

        for (int i = 0; i < Weapons.Count; i++)
            Weapons[i].gameObject.SetActive(false);
    }

    public void UseActive()
    {
        if (ActiveWeapon == null || lastUseTime != -1 && Time.time - lastUseTime < ActiveWeapon.UseCooldown)
            return;

        if (!ActiveWeapon.IsUsable())
        {
            if (ActiveWeapon.UseFailClip != null)
                AudioSource.PlayClipAtPoint(ActiveWeapon.UseFailClip, transform.position);
            return;
        }

        lastUseTime = Time.time;

        ActiveWeapon.UseCount--;
        ActiveWeapon.Use();

        if (ActiveWeapon.UseClip != null)
            AudioSource.PlayClipAtPoint(ActiveWeapon.UseClip, transform.position);
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
