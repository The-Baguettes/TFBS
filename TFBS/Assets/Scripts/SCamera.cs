using UnityEngine;
using System.Collections;

public class SCamera : MonoBehaviour
{
    public bool isPlayer;
    Vector3 minAngle;
    Vector3 maxAngle;
    Vector3 targetAngle;
    public float toRotateLeft;
   // public float toRotateRight;
    public float smooth;
    float animationStartTime;
    public  GameObject ToMove;
    bool spotted;
    bool final;
    float animationProgress = 0.0f;
    
    void Start()
    {
        minAngle = ToMove.transform.eulerAngles + new Vector3(0, -toRotateLeft / 2, 0);
        maxAngle = ToMove.transform.eulerAngles + new Vector3(0, toRotateLeft / 2, 0);
        targetAngle = minAngle;

    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == Tags.Player)
        {
            Alarm();   
        }
    }

    public void Alarm()
    {
            
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
        ToMove.transform.eulerAngles = Vector3.Lerp(ToMove.transform.eulerAngles, targetAngle,animationProgress);
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
}
