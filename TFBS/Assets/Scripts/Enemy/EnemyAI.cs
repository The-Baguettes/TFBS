using UnityEngine;
using System.Collections.Generic;

public class EnemyAI : BaseComponent
{
    public GameObject WaypointsContainer;

    EnemySight sight;
    
    BaseGun firearm;
    Transform leader;
    Collider leaderCol;
    NavMeshAgent navAgent;

    bool lookingAround;
    float totalRotation;
    float angleBeforeLookAround;

    bool isFollowingPlayer;

    int currentWaypoint;
    List<Transform> waypoints;

    protected void Awake()
    {
        leader = GameObject.FindWithTag(Tags.Player).transform;
        leaderCol = leader.GetComponent<Collider>();

        firearm = GetComponentInChildren<BaseGun>();
        sight = GetComponentInChildren<EnemySight>();

        waypoints = new List<Transform>(WaypointsContainer.transform.childCount);
        WaypointsContainer.GetComponentsInChildren<Transform>(waypoints);
        waypoints.Remove(WaypointsContainer.transform);

        navAgent = GetComponent<NavMeshAgent>();
    }

    protected override void Start()
    {
        navAgent.SetDestination(waypoints[0].position);
        base.Start();
    }

    #region Event Management
    EnemyDamage enemyDamage;

    protected override void HookUpEvents()
    {
        enemyDamage = GetComponent<EnemyDamage>();
        enemyDamage.HealthPointsChanged += enemyDamage_HealthPointsChanged;

        SurveillanceCam.PlayerSpotted += StartFollowLeader;
        sight.PlayerInSight += sight_PlayerInSight;
    }

    protected override void UnHookEvents()
    {
        if (enemyDamage != null)
            enemyDamage.HealthPointsChanged -= enemyDamage_HealthPointsChanged;

        SurveillanceCam.PlayerSpotted -= StartFollowLeader;
        sight.PlayerInSight -= sight_PlayerInSight;
    }
    #endregion

    #region Event Handling
    void enemyDamage_HealthPointsChanged(int healthPoints, int delta)
    {
        if (!isFollowingPlayer)
            StartLookAround();
    }

    void sight_PlayerInSight(Vector3 spottedAt)
    {
        if (lookingAround)
            StopLookAround();

        StartFollowLeader(leader.transform.position);
        Shoot();
    }
    #endregion

    void Update()
    {
        if (lookingAround)
            UpdateLookAround();
        else if (isFollowingPlayer)
            UpdateFollowLeader();
        else if (isAtDestination())
        {
            currentWaypoint = ++currentWaypoint % waypoints.Count;
            navAgent.SetDestination(waypoints[currentWaypoint].position);
        }
    }

    #region FollowLeader
    void StartFollowLeader(Vector3 leaderPosition)
    {
        isFollowingPlayer = true;
        navAgent.SetDestination(leaderPosition);
    }

    void UpdateFollowLeader()
    {
        if (sight.IsVisible(leaderCol))
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

    bool isAtDestination()
    {
        return !navAgent.pathPending && navAgent.remainingDistance <= 1
               && (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f);
    }

    void Shoot()
    {
        if (firearm.UsesLeft == 0)
            firearm.Reload();

        transform.LookAt(leader);
        firearm.Use(leader);
    }
}
