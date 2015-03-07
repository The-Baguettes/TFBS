using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BotAI : MonoBehaviour
{
    public Transform waypoint1;
    public Transform waypoint2;
    public Transform waypoint3;

    int w;
    Vector3[] waypoints;

    void Start()
    {
        waypoints = new Vector3[] {waypoint1.position, waypoint2.position ,waypoint3.position};
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = waypoints[0]; 
        //Leader = GameObject.FindWithTag(Tags.Player).transform;
    }

    void Update()
    {
       if (Vector3.Distance(transform.position, waypoints[w]) < 0.2)
           GetComponent<NavMeshAgent>().SetDestination(waypoints[w = (w + 1) % waypoints.Length]);
    }
}
