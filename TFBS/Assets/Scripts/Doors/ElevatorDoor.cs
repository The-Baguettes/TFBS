using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    public float XOffsetFromCenter;
    public float YOffsetFromCenter;
    public float ZOffsetFromCenter;

    DoorTrigger doorTrigger;

    Vector3 positionOpened;
    Vector3 positionClosed;

    void Start()
    {
        doorTrigger = GetComponentInParent<DoorTrigger>();

        positionClosed = transform.position;
        positionOpened = new Vector3(positionClosed.x + XOffsetFromCenter, positionClosed.y + YOffsetFromCenter, positionClosed.z + ZOffsetFromCenter);
    }

    void Update()
    {
        if (doorTrigger.IsPlayerNear)
        {
            if (transform.position == positionOpened)
                doorTrigger.AnimationProgress = 0.0f;
            else
                transform.position = Vector3.Lerp(positionClosed, positionOpened, doorTrigger.AnimationProgress);
        }
        else
        {
            if (transform.position == positionClosed)
                doorTrigger.AnimationProgress = 0.0f;
            else
                transform.position = Vector3.Lerp(positionOpened, positionClosed, doorTrigger.AnimationProgress);
        }
    }
}
