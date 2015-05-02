using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    public int XOffsetFromCenter;
    public int YOffsetFromCenter;
    public int ZOffsetFromCenter;
    bool isPlayerNear = false;
    float animationProgress = 0.0f;
    
    Vector3 positionOpened;
    Vector3 positionClosed;

    void Start()
    {
        positionClosed = transform.position;
        positionOpened  = new Vector3(positionClosed.x + XOffsetFromCenter, positionClosed.y +YOffsetFromCenter, positionClosed.z + ZOffsetFromCenter);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.Player)
            isPlayerNear = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == Tags.Player)
            isPlayerNear = false;
    }

    void Update()
    {
        if (isPlayerNear)
        {
            if (transform.position == positionOpened)
                animationProgress = 0.0f;
            else
                transform.position = Vector3.Lerp(positionClosed, positionOpened, animationProgress);
        }
        else
        {
            if (transform.position == positionClosed)
                animationProgress = 0.0f;
            else
               transform.position = Vector3.Lerp(positionOpened, positionClosed, animationProgress);
        }

        animationProgress += Time.deltaTime;
    }
}
