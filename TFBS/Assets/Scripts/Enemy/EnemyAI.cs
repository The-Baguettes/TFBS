using UnityEngine;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    const int fieldOfView = 120 / 2;
    
    public GameObject WaypointsContainer;

    Transform leader;
    NavMeshAgent navAgent;

    bool lookingAround;
    bool canEndLookAround;
    bool isFollowingPlayer;
    float angleBeforeLookAround;

    int currentWaypoint;
    List<Transform> waypoints;

    void Start()
    {
        leader = GameObject.FindWithTag(Tags.Player).transform;
        
        waypoints = new List<Transform>();
        WaypointsContainer.GetComponentsInChildren<Transform>(waypoints);
        waypoints.Remove(WaypointsContainer.transform);

        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        if (lookingAround)
        {
            UpdateLookAround();

            if (isLeaderInSight())
            {
                lookingAround = false;
                isFollowingPlayer = true;
                navAgent.SetDestination(leader.transform.position);
            }

            return;
        }

        if (isFollowingPlayer)
        {
            if (!isLeaderInSight())
            {
                isFollowingPlayer = false;
                StartLookAround();
            }
            else
                navAgent.SetDestination(leader.transform.position);
        }
        else if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 1)
        {
            isFollowingPlayer = false;
            navAgent.SetDestination(waypoints[currentWaypoint = ++currentWaypoint % waypoints.Count].position);
        }
    }

    #region LookAround
    void StartLookAround()
    {
        lookingAround = true;
        canEndLookAround = false;
        angleBeforeLookAround = transform.eulerAngles.y;
    }

    void UpdateLookAround()
    {
        if (!canEndLookAround)
        {
            if (transform.eulerAngles.y < angleBeforeLookAround)
                // We passed first step in the rotation
                canEndLookAround = true;
        }
        else if (transform.eulerAngles.y >= angleBeforeLookAround)
            // The full turn is done
            EndLookAround();
    
        transform.Rotate(Vector3.up, 60f * Time.deltaTime);
    }

    void EndLookAround()
    {
        lookingAround = false;

        // Go back to the exact rotation before looking around
        transform.Rotate(Vector3.up, angleBeforeLookAround - transform.eulerAngles.y);

        // Resume patrol
        navAgent.SetDestination(waypoints[currentWaypoint].position);
    }
    #endregion

    void OnTriggerStay(Collider col)
    {
        if (col.transform == leader && isLeaderInFieldOfView() && isLeaderInSight())
        {
            isFollowingPlayer = true;
            navAgent.SetDestination(leader.transform.position);
        }
    }

    bool isLeaderInFieldOfView()
    {
        return Vector3.Angle(leader.position - transform.position, transform.forward) < fieldOfView;
    }

    bool isLeaderInSight()
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position, transform.forward, out hit) && hit.collider.tag == Tags.Player;
    }
}
