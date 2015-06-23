using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    Animator animator;
    NavMeshAgent navAgent;

    void Awake()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponentInParent<NavMeshAgent>();
    }

    void Update()
    {
        if (navAgent.speed == 0)
            animator.Play(Animations.IdleAiming);
        else
            animator.Play(Animations.WalkForwardAiming);
    }
}
