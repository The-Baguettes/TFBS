﻿using UnityEngine;

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
        doorTrigger.AnimationProgress = 1;

        positionClosed = transform.position;
        positionOpened = new Vector3(positionClosed.x + XOffsetFromCenter, positionClosed.y + YOffsetFromCenter, positionClosed.z + ZOffsetFromCenter);
    }

    void Update()
    {
        if (doorTrigger.IsPlayerNear)
            transform.position = Vector3.Lerp(positionClosed, positionOpened, doorTrigger.AnimationProgress);
        else
            transform.position = Vector3.Lerp(positionOpened, positionClosed, doorTrigger.AnimationProgress);
    }
}
