using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    const float sprintSpeed = 10f;
    const float walkSpeed = 7f;
    const float sneakSpeed = 5f;
    const float rotationSpeed = 200f;

    Animator animator;
    new NetworkView networkView;
    WeaponManager weaponManager;

    void Awake()
    {
        animator = GetComponent<Animator>();
        networkView = GetComponent<NetworkView>();
        weaponManager = GetComponentInChildren<WeaponManager>();
    }

    void Move(float amount_h, float amount_v, float speed, string anim_f, string anim_b, string anim_l = null, string anim_r = null)
    {
        if (amount_v == 0 && amount_h == 0)
        {
            if (weaponManager.ActiveGun == null)
            {
                animator.Play(Animations.Idle);
                if (networkView != null)
                    networkView.RPC("PlayAnimation", RPCMode.Others, Animations.Idle);
            }
            else
            {
                animator.Play(Animations.IdleAiming);
                if (networkView != null)
                    networkView.RPC("PlayAnimation", RPCMode.Others, Animations.IdleAiming);
            }

            return;
        }

        string anim;
        if (amount_h != 0)
            anim = amount_h < 0 ? anim_l : anim_r;
        else
            anim = amount_v > 0 ? anim_f : anim_b;

        animator.Play(anim);
        if (networkView != null)
            networkView.RPC("PlayAnimation", RPCMode.Others, anim);

        transform.Translate(amount_h * speed * Time.deltaTime, 0, amount_v * speed * Time.deltaTime);
    }

    public void Sneak(float amount_h, float amount_v)
    {
        if (weaponManager.ActiveGun == null)
            Move(amount_h, amount_v, sneakSpeed, Animations.SneakForward, Animations.SneakBackwards);
        else
            Move(amount_h, amount_v, sneakSpeed, Animations.SneakForwardAiming, Animations.SneakBackwardsAiming);
    }

    public void Sprint(float amount_h, float amount_v)
    {
        if (weaponManager.ActiveGun == null)
            Move(amount_h, amount_v, sprintSpeed, Animations.SprintForward, Animations.SprintBackwards);
        else
            Move(amount_h, amount_v, sprintSpeed, Animations.SprintForwardAiming, Animations.SprintBackwardsAiming);
    }

    public void Walk(float amount_h, float amount_v)
    {
        if (weaponManager.ActiveGun == null)
        {
            Move(amount_h, amount_v, walkSpeed,
                Animations.WalkForward, Animations.WalkBackwards,
                Animations.StrafeLeft, Animations.StrafeRight
            );
        }
        else
            Move(amount_h, amount_v, walkSpeed,
                Animations.WalkForwardAiming, Animations.WalkBackwardsAiming,
                Animations.StrafeLeftAiming, Animations.StrafeRightAiming
            );
    }
}
