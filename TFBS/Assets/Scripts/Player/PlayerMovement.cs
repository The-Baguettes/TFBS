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

    void Move(float amount, float speed, string anim_f, string anim_b)
    {
        if (amount == 0)
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

        animator.Play(amount > 0 ? anim_f : anim_b);
        if (networkView != null)
            networkView.RPC("PlayAnimation", RPCMode.Others, amount > 0 ? anim_f : anim_b);

        transform.Translate(0, 0, amount * speed * Time.deltaTime);
    }

    public void Sneak(float amount)
    {
        if (weaponManager.ActiveGun == null)
            Move(amount, sneakSpeed, Animations.SneakForward, Animations.SneakBackwards);
        else
            Move(amount, sneakSpeed, Animations.SneakForwardAiming, Animations.SneakBackwardsAiming);
    }

    public void Sprint(float amount)
    {
        if (weaponManager.ActiveGun == null)
            Move(amount, sprintSpeed, Animations.SprintForward, Animations.SprintBackwards);
        else
            Move(amount, sprintSpeed, Animations.SprintForwardAiming, Animations.SprintBackwardsAiming);
    }

    public void Walk(float amount)
    {
        if (weaponManager.ActiveGun == null)
            Move(amount, walkSpeed, Animations.WalkForward, Animations.WalkBackwards);
        else
            Move(amount, walkSpeed, Animations.WalkForwardAiming, Animations.WalkBackwardsAiming);
    }

    public void Rotate(float amount)
    {
        transform.Rotate(0, amount * rotationSpeed * Time.deltaTime, 0);
    }
}
