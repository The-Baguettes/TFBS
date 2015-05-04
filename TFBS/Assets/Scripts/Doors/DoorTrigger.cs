using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public float AnimationSpeed = 1;

    [HideInInspector]
    public float AnimationProgress;
    [HideInInspector]
    public bool IsPlayerNear;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.Player)
        {
            IsPlayerNear = true;

            if (AnimationProgress != 0)
                AnimationProgress = 1 - AnimationProgress;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == Tags.Player)
        {
            IsPlayerNear = false;

            if (AnimationProgress != 0)
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
