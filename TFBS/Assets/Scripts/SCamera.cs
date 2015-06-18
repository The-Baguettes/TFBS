using UnityEngine;
using System.Collections;

public class SCamera : MonoBehaviour
{
    public bool isPlayer;
    Vector3 minAngle;
    Vector3 maxAngle;
    Vector3 targetAngle;
    public float toRotate;
    public float smooth;
    float animationStartTime;
    bool vrai;
    bool final;
    float animationProgress = 0.0f;
    
    void Start()
    {
        minAngle = transform.eulerAngles + new Vector3(0,  - toRotate / 2, 0);
        maxAngle = transform.eulerAngles + new Vector3(0, +toRotate / 2, 0);
        targetAngle = minAngle;

    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == Tags.Player)
        {
            
            //TO DO DETECT PLAYER
        }
    }

    
    IEnumerator Displacement()
    {
        yield return new WaitForSeconds(5f);
    }


    void Update() 
    {
        if(Time.time <= animationStartTime)
        {
            return;
        }
        animationProgress += Time.deltaTime*smooth;
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngle,animationProgress);
        if(animationProgress >= 1)
        {
            animationProgress = 0;
            animationStartTime = Time.time + 5f;
            if (targetAngle == minAngle)
                targetAngle = maxAngle;
            else
                targetAngle = minAngle;
        }
    }
    /*void Update()
    {
                if (final)
                {
                    if (ToMove.transform.position == positionDown)
                    {
                        final = !final;
                        //vrai = !vrai;
                    }
                    else
                    {
                        if (ToMove.transform.position == positionUp && vrai)
                        {
                            StartCoroutine(Displacement());
                            animationProgress = 0.0f;
                            vrai = !vrai;
                            ToMove.transform.position = new Vector3(ToMove.transform.position.x - 0.0001f, ToMove.transform.position.y - 0.0001f, ToMove.transform.position.z - 0.0001f);
                        }
                        else
                        {
                            ToMove.transform.position = Vector3.Lerp(positionUp, positionDown, animationProgress / smooth);
                        }
                    }
                }
                else
                {
                    {
                        if (ToMove.transform.position == positionUp)
                        {
                            final = !final;
                            vrai = !vrai;
                        }
                        else
                        {
                            if (ToMove.transform.position == positionDown && vrai)
                            {
                                StartCoroutine(Displacement());
                                animationProgress = 0.0f;
                                vrai = !vrai;
                                ToMove.transform.position = new Vector3(ToMove.transform.position.x + 0.0001f, ToMove.transform.position.y + 0.0001f, ToMove.transform.position.z + 0.0001f);
                            }
                            else
                            {
                                ToMove.transform.position = Vector3.Lerp(positionDown, positionUp, animationProgress / smooth);
                            }
                        }
                    }
                }
            }
    }*/
}
