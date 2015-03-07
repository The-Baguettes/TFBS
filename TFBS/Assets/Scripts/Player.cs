using UnityEngine;

public class Player : MonoBehaviour
{
    public float sprintSpeed = 15f;
    public float movementSpeed = 10f;
    public float sneakSpeed = 5f;
    public float turningSpeed = 200f;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        bool sneak = Input.GetButton(Inputs.Sneak);
        bool sprint = Input.GetButton(Inputs.Sprint);

        float horizontal = Input.GetAxis(Inputs.Horizontal);
        float vertical = Input.GetAxis(Inputs.Vertical);

        transform.Rotate(0, horizontal * turningSpeed * Time.deltaTime, 0);

        if (vertical == 0)
        {
            animator.Play(Animations.Idle);
            return;
        }

        if (sneak)
        {
            animator.Play(vertical > 0 ? Animations.SneakForwards: Animations.SneakBackwards);
            transform.Translate(0, 0, vertical * sneakSpeed * Time.deltaTime);
        }
        else if (sprint)
        {
            animator.Play(vertical > 0 ? Animations.RunForwards : Animations.RunBackwards);
            transform.Translate(0, 0, vertical * sprintSpeed * Time.deltaTime);
        }
        else
        {
            animator.Play(vertical > 0 ? Animations.WalkForwards : Animations.WalkBackwards);
            transform.Translate(0, 0, vertical * movementSpeed * Time.deltaTime);
        }
    }
}
