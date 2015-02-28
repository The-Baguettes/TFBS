using UnityEngine;
using System.Collections;

public class BotAI : MonoBehaviour
{
    float AIspeed = 3.5f;
    float MaxDistance = 50f;
    float MinDistance = 1f;
    float AIrotate = 90f;

    Transform Leader;
    bool AImoving = true;

    void Start()
    {
        Leader = GameObject.FindWithTag(Tags.Player).transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, Leader.position);

        if (distance == MinDistance)
            transform.LookAt(Leader); 
        else if (MinDistance < distance && distance <= MaxDistance)
        {
            transform.position += transform.forward * AIspeed * Time.deltaTime;
            transform.LookAt(Leader);
        }
        else
            StartCoroutine(Patrol());

    }

    IEnumerator Patrol()
    {
        if (AImoving)
        {
            transform.position += transform.forward * AIspeed * Time.deltaTime;
            yield return new WaitForSeconds(1.5f);
            AImoving = false;
        }
        transform.Rotate(0, AIrotate * Time.deltaTime, 0);
        yield return new WaitForSeconds(1.5f);
        AImoving = true;
    }
}
