using UnityEngine;
using System.Collections;

public class SCamera : MonoBehaviour
{
   // public bool isPlayer;
    Vector3 minAngle;
    Vector3 maxAngle;
    Vector3 targetAngle;
    public float toRotateLeft;
    // public float toRotateRight;
    public float smooth;
    float animationStartTime;
    public GameObject ToMove;
    bool spotted;
    bool final;
    float animationProgress = 0.0f;
    public GameObject redLight;
    void Start()
    {
        minAngle = ToMove.transform.eulerAngles + new Vector3(0, -toRotateLeft / 2, 0);
        maxAngle = ToMove.transform.eulerAngles + new Vector3(0, toRotateLeft / 2, 0);
        targetAngle = minAngle;
        spotted = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.Player)
            spotted = true;
    }

    void OnTriggerExit(Collider col)
    {
        if(col.tag== Tags.Player && spotted)
        {
            StartCoroutine(Alarm());
        }
    }

    IEnumerator Alarm()
    {
        if (spotted)
        {
            for (int i = 0; i < 10; i++)
            {//sound
                redLight.SetActive(true);
                yield return new WaitForSeconds(2f);
                redLight.SetActive(false);
                yield return new WaitForSeconds(1f);
            }
        }
    }

    IEnumerator Displacement(float a)
    {
        yield return new WaitForSeconds(a);
    }


    void Update()
    {
        if (Time.time <= animationStartTime)
        {
            return;
        }
        animationProgress += Time.deltaTime * smooth;
        ToMove.transform.eulerAngles = Vector3.Lerp(ToMove.transform.eulerAngles, targetAngle, animationProgress);
        if (animationProgress >= 1)
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
