using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    static readonly KeyCode[] weaponInputs = {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
    };

    new NetworkView networkView;
    PlayerMovement playerMovement;
    WeaponManager weaponManager;

    void Start()
    {
        networkView = GetComponent<NetworkView>();
        playerMovement = GetComponent<PlayerMovement>();
        weaponManager = GetComponentInChildren<WeaponManager>();
    }

    void Update()
    {
        if (MenuBase.IsPaused)
            return;

        float move_h = Input.GetAxis(Inputs.Horizontal);
        float move_v = Input.GetAxis(Inputs.Vertical);

        if (Input.GetButton(Inputs.Sneak))
            playerMovement.Sneak(move_h, move_v);
        else if (Input.GetButton(Inputs.Sprint))
            playerMovement.Sprint(move_h, move_v);
        else
            playerMovement.Walk(move_h, move_v);

        for (int i = 0; i < weaponInputs.Length; i++)
        {
            if (Input.GetKeyDown(weaponInputs[i]) && PlayerBonus.weaponsAvailable[i])
            {
                weaponManager.SwitchToWeapon(i);
                if (networkView != null)
#pragma warning disable 0618
                    networkView.RPC("SwitchToWeapon", RPCMode.Others, i);
#pragma warning restore 0618

                return;
            }
        }

        if (Input.GetButton(Inputs.Fire))
        {
            weaponManager.UseActive();
            if (networkView != null)
#pragma warning disable 0618
                networkView.RPC("UseActive", RPCMode.Others);
#pragma warning restore 0618
        }
        else if (weaponManager.ActiveGun != null)
        {
            if (Input.GetButtonDown(Inputs.WeaponMeta))
            {
                weaponManager.ActiveGun.ToggleSilencer();
                if (networkView != null)
#pragma warning disable 0618
                    networkView.RPC("ToggleSilencer", RPCMode.Others);
#pragma warning restore 0618
            }
            else if (Input.GetButtonDown(Inputs.Reload))
            {
                weaponManager.ActiveGun.Reload();
                if (networkView != null)
#pragma warning disable 0618
                    networkView.RPC("Reload", RPCMode.Others);
#pragma warning restore 0618
            }
        }
    }
}
