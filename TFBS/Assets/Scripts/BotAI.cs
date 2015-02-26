using UnityEngine;
using System;
using System.Collections;

public class BotAI : MonoBehaviour
{
    Transform Leader;
    float AIspeed = 3.5f;
    float MaxDistance = 50.0f;
    float AIrotate = 90.0f;
    bool AImoving = true;

    void Start()
    {
        Leader = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        AI();
    }

    void AI()
    {
        if (Vector3.Distance(transform.position, Leader.position ) <= MaxDistance)
        {
            transform.position += transform.forward * AIspeed * Time.deltaTime;
            transform.LookAt(Leader);
        }

        else { StartCoroutine(Patrol()); }

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
