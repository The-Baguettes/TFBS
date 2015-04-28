using UnityEngine;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    const int fieldOfView = 160 / 2;
    
    public GameObject WaypointsContainer;

    Transform leader;
    NavMeshAgent navAgent;

    bool lookingAround;
    float totalRotation;
    float angleBeforeLookAround;

    bool isFollowingPlayer;

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
            UpdateLookAround();
        else if (isFollowingPlayer)
            UpdateFollowLeader();
        else if (!navAgent.pathPending && navAgent.remainingDistance <= 1
                 && (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f))
        {
            currentWaypoint = ++currentWaypoint % waypoints.Count;
            navAgent.SetDestination(waypoints[currentWaypoint].position);
        }
    }

    #region FollowLeader
    void StartFollowLeader()
    {
        isFollowingPlayer = true;
        navAgent.SetDestination(leader.transform.position);
    }

    void UpdateFollowLeader()
    {
        if (!isLeaderInSight())
        {
            isFollowingPlayer = false;
            StartLookAround();
        }
    }
    #endregion

    #region LookAround
    void StartLookAround()
    {
        lookingAround = true;
        angleBeforeLookAround = transform.eulerAngles.y;
        totalRotation = 0f;

        if (navAgent.isOnNavMesh)
            navAgent.Stop();
    }

    void UpdateLookAround()
    {
        float rot = 200f * Time.deltaTime;
        totalRotation += rot;

        if (totalRotation < 360)
            transform.Rotate(Vector3.up, rot);
        else
            // The full turn is done
            CompleteLookAround();
    }

    void StopLookAround()
    {
        navAgent.Resume();
        lookingAround = false;
    }

    void CompleteLookAround()
    {
        StopLookAround();

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
            if (lookingAround)
                StopLookAround();
            StartFollowLeader();
        }
    }

    public void OnTakeDamage()
    {
        if (!isFollowingPlayer)
            StartLookAround();
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
