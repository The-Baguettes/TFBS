using UnityEngine;
using System.Collections;

public class PlayerClient : MonoBehaviour
{
    Animator animator;
    WeaponManager weaponManager;

    void Start()
    {
        animator = GetComponent<Animator>();
        weaponManager = GetComponentInChildren<WeaponManager>();
    }

    [RPC]
    void PlayAnimation(string anim)
    {
        animator.Play(anim);
    }

    [RPC]
    void SwitchToWeapon(int n)
    {
        weaponManager.SwitchToWeapon(n);
    }

    [RPC]
    void UseActive()
    {
        weaponManager.UseActive();
    }

    [RPC]
    void ToggleSilencer()
    {
        weaponManager.ActiveGun.ToggleSilencer();
    }

    [RPC]
    void Reload()
    {
        weaponManager.ActiveGun.Reload();
    }
}
