﻿using UnityEngine;
using System.Collections;

public class Hostage : MonoBehaviour
{
    Transform leader;
    NavMeshAgent navmesh;

    void Awake()
    {
        navmesh = GetComponent<NavMeshAgent>();
        navmesh.stoppingDistance = 4.0f;
        navmesh.speed = 10f;
    }

    void Update()
    {
        if (leader != null)
        {
            navmesh.SetDestination(leader.transform.position);
            GetComponent<Animation>().Play();
        }
    }

    public void Follow(Transform leader)
    {
        this.leader = leader;
    }

}
