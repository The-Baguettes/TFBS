using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    const float sprintSpeed = 15f;
    const float walkSpeed = 10f;
    const float sneakSpeed = 5f;
    const float rotationSpeed = 200f;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Move(float amount, float speed, string anim_f, string anim_b)
    {
        if (amount == 0)
        {
            animator.Play(Animations.Idle);
            return;
        }

        animator.Play(amount > 0 ? anim_f : anim_b);
        transform.Translate(0, 0, amount * speed * Time.deltaTime);
    }

    public void Sneak(float amount)
    {
        Move(amount, sneakSpeed, Animations.SneakForwards, Animations.SneakBackwards);

    }

    public void Sprint(float amount)
    {
        Move(amount, sprintSpeed, Animations.SprintForwards, Animations.SprintBackwards);

    }

    public void Walk(float amount)
    {
        Move(amount, walkSpeed, Animations.WalkForwards, Animations.WalkBackwards);
    }

    public void Rotate(float amount)
    {
        transform.Rotate(0, amount * rotationSpeed * Time.deltaTime, 0);
    }
}
