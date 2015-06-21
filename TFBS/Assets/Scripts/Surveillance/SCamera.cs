using UnityEngine;
using System.Collections;

public class SCamera : MonoBehaviour
{
    // public bool isPlayer;
    Vector3 minAngle;
    Vector3 maxAngle;
    Vector3 targetAngle;
    public float toRotateLeft;
    public GameObject audio;
    // public float toRotateRight;
    public float smooth;
    float animationStartTime;
    public GameObject ToMove;
    [HideInInspector]
    public bool spotted;
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
        {
            spotted = true;
            StartCoroutine(Alarm());
        }
    }


    IEnumerator Alarm()
    {
        if (spotted)
        {
            for (int i = 0; i < 2; i++)
            {
                audio.GetComponent<AudioSource>().Play();
                redLight.SetActive(true);
                yield return new WaitForSeconds(3f);
                redLight.SetActive(false);
                yield return new WaitForSeconds(0.5f);
            }
        }
        spotted = false;
    }



    // TO FIX 
    /*IEnumerable Alarm2()
    {
        List<Light> redList = new List<Light>(redLight.transform.childCount);
        redLight.GetComponentsInChildren<Light>(redList);
        while (redList.Count != 0)
        {
            for (int i = 0; i < redList.Count; i++)
            {
                redList[i].intensity -= 0.1f;
                if (redList[i].intensity <= 0)
                {
                    redList.RemoveAt(i);
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
        redLight.GetComponentsInChildren<Light>(redList);
        while (redList.Count != 0)
        {
            for (int i = 0; i < redList.Count; i++)
            {
                redList[i].intensity += 0.1f;
                if (redList[i].intensity <= redLight.transform.GetChild(i).GetComponent<Light>().intensity)
                {
                    redList.RemoveAt(i);
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }*/

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
