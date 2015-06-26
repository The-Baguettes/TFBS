using UnityEngine;

public class CivilAnimator : MonoBehaviour
{
    Animation animator;
    NavMeshAgent navAgent;

    void Awake()
    {
        animator = GetComponent<Animation>();
        navAgent = GetComponentInParent<NavMeshAgent>();
    }

    void Update()
    {
        if (navAgent.velocity.sqrMagnitude == 0)
            animator.Play("idle");
        else
            animator.Play("walk");
    }
}
