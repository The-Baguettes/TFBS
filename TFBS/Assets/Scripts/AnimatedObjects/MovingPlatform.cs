using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    public float XOffsetFromCenter;
    public float YOffsetFromCenter;
    public float ZOffsetFromCenter;
    public int withPlayer;
    int startwithPlayer;
    bool isPlayerOn;
    public GameObject ToMove;
    public GameObject Player;
    public float smooth;
    Vector3 positionUp;
    Vector3 positionDown;
    
    bool up;
    float animationProgress = 0.0f;

    void Start()
    {
        positionUp = ToMove.transform.position;
        //Up = ToMove.transform.position;
        //Down = new Vector3(Up.x + XOffsetFromCenter, Up.y + YOffsetFromCenter, Up.z + ZOffsetFromCenter);
        positionDown = new Vector3(positionUp.x + XOffsetFromCenter, positionUp.y + YOffsetFromCenter, positionUp.z + ZOffsetFromCenter);
        up = true;
        isPlayerOn = false;
        startwithPlayer = withPlayer;
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
                if(ToMove.transform.position ==positionDown )
                {
                    withPlayer = 0;
                }
                if (ToMove.transform.position == positionUp)
                {
                    withPlayer = startwithPlayer;
                    animationProgress = 0.0f;
                    ToMove.transform.position = new Vector3(ToMove.transform.position.x - 0.0001f, ToMove.transform.position.y - 0.0001f, ToMove.transform.position.z - 0.0001f);
                }
                else
                {
                    UpDown(withPlayer);
                    ToMove.transform.position = Vector3.Lerp(positionUp, positionDown, animationProgress/smooth);                   
                }
            }
            if (!up)
            {
                if (ToMove.transform.position == positionUp)
                {
                    withPlayer = 0;
                }
                if (ToMove.transform.position == positionDown)
                {
                    withPlayer = startwithPlayer;
                    animationProgress = 0.0f;
                    ToMove.transform.position = new Vector3(ToMove.transform.position.x + 0.0001f, ToMove.transform.position.y + 0.0001f, ToMove.transform.position.z + 0.0001f);                   
                }
                else
                {
                    DownUp(withPlayer);
                    ToMove.transform.position = Vector3.Lerp(positionDown, positionUp, animationProgress / smooth);
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

    public void UpDown(int withPlayer) //Takes the player down
    {
        if(withPlayer == 1)
        {
            Player.transform.position = Vector3.Lerp(positionUp,positionDown, animationProgress / smooth);
        }
    }

    public void DownUp(int withPlayer) //Takes the player up 
    {
        if(withPlayer == 1)
        {
            Player.transform.position = Vector3.Lerp(positionDown, positionUp, animationProgress / smooth);
        }
    }

   
}

