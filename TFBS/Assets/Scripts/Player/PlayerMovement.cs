using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    const float sprintSpeed = 15f;
    const float walkSpeed = 10f;
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

    void Move(float amount_h, float amount_v, float speed, string anim_f, string anim_b)
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

        animator.Play(amount_v > 0 ? anim_f : anim_b);
        if (networkView != null)
            networkView.RPC("PlayAnimation", RPCMode.Others, amount_v > 0 ? anim_f : anim_b);

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
            Move(amount_h, amount_v, walkSpeed, Animations.WalkForward, Animations.WalkBackwards);
        else
            Move(amount_h, amount_v, walkSpeed, Animations.WalkForwardAiming, Animations.WalkBackwardsAiming);
    }
}
