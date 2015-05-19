using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Vector3 Translation;

    AnimationTrigger doorTrigger;

    Transform parent;
    Vector3 positionOpened;
    Vector3 positionClosed;

    void Start()
    {
        doorTrigger = GetComponentInParent<AnimationTrigger>();
        doorTrigger.AnimationProgress = 1;

        parent = transform.parent;
        positionClosed = transform.position - parent.position;
        positionOpened = positionClosed + Translation;
    }

    void Update()
    {
        if (doorTrigger.IsPlayerNear)
            transform.position = parent.position + Vector3.Lerp(positionClosed, positionOpened, doorTrigger.AnimationProgress);
        else
            transform.position = parent.position + Vector3.Lerp(positionOpened, positionClosed, doorTrigger.AnimationProgress);
    }
}
