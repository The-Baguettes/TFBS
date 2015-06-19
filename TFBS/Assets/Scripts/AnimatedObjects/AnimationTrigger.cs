using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public float AnimationSpeed = 1;

    [HideInInspector]
    public float AnimationProgress;
    [HideInInspector]
    public bool IsPlayerNear;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.Player || col.tag == Tags.Hostage)
        {
            IsPlayerNear = true;
            AnimationProgress = 1 - AnimationProgress;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == Tags.Player || col.tag == Tags.Hostage)
        {
            IsPlayerNear = false;
            AnimationProgress = 1 - AnimationProgress;
        }
    }

    void Update()
    {
        if (AnimationProgress < 1)
            AnimationProgress += Time.deltaTime * AnimationSpeed;
        else
            AnimationProgress = 1;
    }
}
