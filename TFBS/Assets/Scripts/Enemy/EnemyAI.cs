using UnityEngine;
using System.Collections.Generic;

public class EnemyAI : BaseComponent
{
    const int fieldOfView = 160 / 2;
    
    public GameObject WaypointsContainer;

    BaseGun firearm;

    Transform leader;
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

        firearm = GetComponentInChildren<BaseGun>();

        waypoints = new List<Transform>();
        WaypointsContainer.GetComponentsInChildren<Transform>(waypoints);
        waypoints.Remove(WaypointsContainer.transform);

        navAgent = GetComponent<NavMeshAgent>();
    }

    protected override void Start()
    {
        base.Start();
        navAgent.SetDestination(waypoints[0].position);
    }

    #region EventManagement
    EnemyDamage enemyDamage;

    protected override void HookUpEvents()
    {
        enemyDamage = GetComponent<EnemyDamage>();

        enemyDamage.HealthPointsChanged += enemyDamage_HealthPointsChanged;
    }

    protected override void UnHookEvents()
    {
        if (enemyDamage != null)
            enemyDamage.HealthPointsChanged -= enemyDamage_HealthPointsChanged;
    }
    #endregion

    #region EventHandlers
    void enemyDamage_HealthPointsChanged(int healthPoints, int delta)
    {
        if (!isFollowingPlayer)
            StartLookAround();
    }
    #endregion

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
            Shoot();
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
    
    void Shoot()
    {
        if (firearm.UsesLeft == 0)
            firearm.Reload();
        transform.LookAt(leader);
        firearm.transform.LookAt(leader);
        firearm.transform.Rotate(0, -90, 0);
        firearm.Use(leader);
        
    }
}
