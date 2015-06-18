using UnityEngine;
using System.Collections;

public class Hostage : MonoBehaviour
{
    Transform Ia;
    Transform leader;
    bool followingplayer;
    bool PlayerIsNear=true;
    NavMeshAgent navmesh;
    int rotspeed = 60;

    void Awake()
    {
        leader = GameObject.FindGameObjectWithTag(Tags.Player).transform;
        navmesh = GetComponent<NavMeshAgent>();
        Ia = transform;
    }

    void Update()
    {
        if ((leader.position.x - Ia.transform.position.x) > 1)
            followingplayer = true;
        if (followingplayer && PlayerIsNear)
            FollowingPlayer();
    }

    void FollowingPlayer()
    {
        while (followingplayer)
        {
            if ((leader.position.x - Ia.transform.position.x) <= 1)
                followingplayer = false;
            navmesh.SetDestination(leader.transform.position);
        }
        if (followingplayer == false) 
        {
            Ia.Rotate(0,rotspeed*Time.deltaTime,0);
        }
    }
}
