using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public ElevatorDoor LeftDoor;
    public ElevatorDoor RightDoor;

    [HideInInspector]
    public float AnimationProgress;
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
        AnimationProgress += Time.deltaTime;
    }
}
