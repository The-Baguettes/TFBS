using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BotAI : MonoBehaviour
{
    public Transform waypoint1;
    public Transform waypoint2;
    public Transform waypoint3;
    public Transform Leader;
    int w;
    Vector3[] waypoints;
    RaycastHit hit;

    void Start()
    {
        Leader = GameObject.FindWithTag(Tags.Player).transform;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        if ((Physics.Raycast(transform.position, forward, out hit) && hit.collider.tag == Tags.Player))
        {
            transform.LookAt(Leader);
            transform.position = Leader.transform.position;
        }
        else
        {
            waypoints = new Vector3[] { waypoint1.position, waypoint2.position, waypoint3.position };
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = waypoints[0];

        }
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        if ((Physics.Raycast(transform.position, forward, out hit) && hit.collider.tag == Tags.Player))
        {
            transform.LookAt(Leader);
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination =Leader.transform.position;
        }
        else if (Vector3.Distance(transform.position, waypoints[w]) < 1)
        {
            GetComponent<NavMeshAgent>().SetDestination(waypoints[w = (w + 1) % waypoints.Length]);
        }
    }
}
