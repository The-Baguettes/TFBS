using UnityEngine;
using System.Collections;

public class Hostage : MonoBehaviour
{
    Transform leader;
    NavMeshAgent navmesh;
    int rotspeed = 60;

    void Awake()
    {
        navmesh = GetComponent<NavMeshAgent>();
        navmesh.stoppingDistance = 4.0f;
    }

    void Update()
    {
        if (leader != null)
            navmesh.SetDestination(leader.transform.position);
    }

    public void Follow(Transform leader)
    {
        this.leader = leader;
    }

}
