using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    static KeyCode[] weaponInputs = new KeyCode[]{
        KeyCode.Alpha1,
        KeyCode.Alpha2,
    };

    PlayerMovement playerMovement;
    WeaponManager weaponManager;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        weaponManager = GetComponentInChildren<WeaponManager>();
    }

    void Update()
    {
        if (OverlayMenu.isPaused)
            return;

        float move_h = Input.GetAxis(Inputs.Horizontal);
        float move_v = Input.GetAxis(Inputs.Vertical);

        playerMovement.Rotate(move_h);

        if (Input.GetButton(Inputs.Sneak))
            playerMovement.Sneak(move_v);
        else if (Input.GetButton(Inputs.Sprint))
            playerMovement.Sprint(move_v);
        else
            playerMovement.Walk(move_v);

        for (int i = 0; i < weaponInputs.Length; i++)
        {
            if (Input.GetKeyDown(weaponInputs[i]))
            {
                weaponManager.SwitchToWeapon(i);
                return;
            }
        }

        if (Input.GetButton(Inputs.Fire))
            weaponManager.UseActive();
        else if (weaponManager.ActiveGun != null)
        {
            if (Input.GetButtonDown(Inputs.WeaponMeta))
                weaponManager.ActiveGun.ToggleSilencer();
            else if (Input.GetButtonDown(Inputs.Reload))
                weaponManager.ActiveGun.Reload();
        }
    }
}
