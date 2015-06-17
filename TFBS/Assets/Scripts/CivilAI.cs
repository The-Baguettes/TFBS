using UnityEngine;
using System.Collections.Generic;

public class CivilAI : MonoBehaviour {

    NavMeshAgent navAgent;
    int currentWaypoint;
    List<Transform> waypoints; 
    public GameObject WaypointsContainer;

	void Start ()
    {
        waypoints = new List<Transform>();
        WaypointsContainer.GetComponentsInChildren<Transform>(waypoints);
        waypoints.Remove(WaypointsContainer.transform);

        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(waypoints[0].position);
	}
	void Update () {
        if (!navAgent.pathPending && navAgent.remainingDistance <= 1
                    && (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f))
        {
            currentWaypoint = ++currentWaypoint % waypoints.Count;
            navAgent.SetDestination(waypoints[currentWaypoint].position);
        }
	}
}
