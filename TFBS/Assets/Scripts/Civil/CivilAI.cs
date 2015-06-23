using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilAI : BaseComponent
{
    public Transform WaypointsContainer;
    public Transform HidingPlacesContainer;

    NavMeshAgent navAgent;

    int currentWaypoint;
    List<Transform> waypoints;
    
    bool isHiding;
    bool shouldComeOut;
    List<Transform> hidingPlaces;

    protected void Awake()
    {
        waypoints = new List<Transform>(WaypointsContainer.childCount);
        WaypointsContainer.GetComponentsInChildren<Transform>(waypoints);
        waypoints.Remove(WaypointsContainer);

        hidingPlaces = new List<Transform>(HidingPlacesContainer.childCount);
        HidingPlacesContainer.GetComponentsInChildren<Transform>(hidingPlaces);
        hidingPlaces.Remove(HidingPlacesContainer);

        navAgent = GetComponent<NavMeshAgent>();
    }

    protected override void Start()
    {
        navAgent.SetDestination(waypoints[0].position);

        base.Start();
    }

    #region Event Management
    protected override void HookUpEvents()
    {
        SurveillanceCam.PlayerSpotted += SurveillanceCam_PlayerSpotted;
    }

    protected override void UnHookEvents()
    {
        SurveillanceCam.PlayerSpotted -= SurveillanceCam_PlayerSpotted;
    }
    #endregion

    #region Event Handling
    void SurveillanceCam_PlayerSpotted(Vector3 spottedAt)
    {
        if (!isHiding)
            StartCoroutine(Hide(spottedAt));
    }
    #endregion

    void Update()
    {
        if (!isAtDestination())
            return;

        if (isHiding)
            StartCoroutine(WaitAndComeOut());
        else
        {
            currentWaypoint = ++currentWaypoint % waypoints.Count;
            navAgent.SetDestination(waypoints[currentWaypoint].position);
        }
    }

    bool isAtDestination()
    {
        return !navAgent.pathPending && navAgent.remainingDistance <= 2
               && (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0);
    }

    IEnumerator Hide(Vector3 playerPosition)
    {
        int min = -1;
        float minDistance = 0;

        for (int i = 0; i < hidingPlaces.Count; i++)
        {
            float dist = Vector3.Distance(hidingPlaces[i].position, playerPosition);
            
            if (min == -1 || dist < minDistance)
            {
                min = i;
                minDistance = dist;
            }
        }

        isHiding = true;
    
        if (shouldComeOut)
            shouldComeOut = false;
        else
            navAgent.SetDestination(hidingPlaces[min].position);

        yield return new WaitForEndOfFrame(); // To qualify as a IEnumerator
    }

    IEnumerator WaitAndComeOut()
    {
        shouldComeOut = true;
        yield return new WaitForSeconds(7);

        if (!shouldComeOut)
            navAgent.SetDestination(waypoints[currentWaypoint].position);
    }
}
