using UnityEngine;
using System.Collections;

public class MoveFloor : MonoBehaviour
{
    public float XOffsetFromCenter;
    public float YOffsetFromCenter;
    public float ZOffsetFromCenter;
    bool isPlayerOn;
    Vector3 positionUp;
    Vector3 positionDown;

    bool up;
    float animationProgress = 0.0f;

    void Start()
    {
        positionUp = transform.position;
        positionDown = new Vector3(positionUp.x + XOffsetFromCenter, positionUp.y + YOffsetFromCenter, positionUp.z + ZOffsetFromCenter);
        up = true;
        isPlayerOn = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.Player)
            isPlayerOn = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == Tags.Player)
        {
            isPlayerOn = false;
            up = !up;
        }
    }
    void FixedUpdate()
    {
        if (isPlayerOn)
        {
            if (up)
            {
                if (transform.position == positionUp)
                {
                    animationProgress = 0.0f;
                    transform.position = new Vector3(transform.position.x - 0.0001f, transform.position.y - 0.0001f, transform.position.z - 0.0001f);
                }
                else
                {
                    transform.position = Vector3.Lerp(positionUp, positionDown, animationProgress/3f);
                }
            }
            if (!up)
            {
                if (transform.position == positionDown)
                {
                    animationProgress = 0.0f;
                    transform.position = new Vector3(transform.position.x + 0.0001f, transform.position.y + 0.0001f, transform.position.z + 0.0001f);
                   
                }
                else
                {
                    transform.position = Vector3.Lerp(positionDown, positionUp, animationProgress/3.0f);
                }   
            }

        }
        if(!isPlayerOn)
        {
            if(up)
            {
                transform.position = positionUp;
            }
            else
            {
                transform.position = positionDown;
            }
        }
        
        animationProgress += Time.deltaTime;


    }


}

