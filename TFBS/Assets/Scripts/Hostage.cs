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
        GetComponent<Animation>().Play("Idle_Combat_Base");
        if (leader != null)
        {
            navmesh.SetDestination(leader.transform.position);
            GetComponent<Animation>().Play("Move_Sprint450");
        }
    }

    public void Follow(Transform leader)
    {
        this.leader = leader;
    }

}
