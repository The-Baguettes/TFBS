using UnityEngine;
using System.Collections;

public class MoveFloor : MonoBehaviour
{
    public float XOffsetFromCenter;
    public float YOffsetFromCenter;
    public float ZOffsetFromCenter;
    bool isPlayerOn;
    public GameObject ToMove;
    Vector3 positionUp;
    Vector3 positionDown;

    bool up;
    float animationProgress = 0.0f;

    void Start()
    {
        positionUp = ToMove.transform.position;
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
                if (ToMove.transform.position == positionUp)
                {
                    animationProgress = 0.0f;
                    ToMove.transform.position = new Vector3(ToMove.transform.position.x - 0.0001f, ToMove.transform.position.y - 0.0001f, ToMove.transform.position.z - 0.0001f);
                }
                else
                {
                    ToMove.transform.position = Vector3.Lerp(positionUp, positionDown, animationProgress/3.0f);
                }
            }
            if (!up)
            {
                if (ToMove.transform.position == positionDown)
                {
                    animationProgress = 0.0f;
                    ToMove.transform.position = new Vector3(ToMove.transform.position.x + 0.0001f, ToMove.transform.position.y + 0.0001f, ToMove.transform.position.z + 0.0001f);
                   
                }
                else
                {
                    ToMove.transform.position = Vector3.Lerp(positionDown, positionUp, animationProgress/3.0f);
                }   
            }

        }
        if(!isPlayerOn)
        {
            if(up)
            {
                ToMove.transform.position = positionUp;
            }
            else
            {
                ToMove.transform.position = positionDown;
            }
        }
        
        animationProgress += Time.deltaTime;


    }


}

