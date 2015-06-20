using UnityEngine;
using System.Collections.Generic;

public class CivilAI : MonoBehaviour
{

    NavMeshAgent navAgent1;
    NavMeshAgent navAgent2;
    int currentWaypoint;
    List<Transform> wayList1;
    List<Transform> wayList2;
    public GameObject wayPoints;
    GameObject WaypointsContainer1;
    GameObject WaypointsContainer2;
   // public GameObject hidingPlace;
    //public GameObject player;    
    [HideInInspector]
    public int isSpotted;
/*void Start()
    { 
        isSpotted = GameObject.Find("Surveillance").GetComponent<RepCam>().lastSpotted;
        if (isSpotted > 0)
            WaypointsContainer = wayPoints.transform.GetChild(0).gameObject; 
        else
            WaypointsContainer = wayPoints.transform.GetChild(1).gameObject;          
        wayList = new List<Transform>();
        WaypointsContainer.GetComponentsInChildren<Transform>(wayList);
        wayList.Remove(WaypointsContainer.transform);
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(wayList[0].position);
    }*/
    /*void Update()
    {
        if (isSpotted > 0)
            WaypointsContainer = wayPoints.transform.GetChild(0).gameObject;
        else
            WaypointsContainer = wayPoints.transform.GetChild(1).gameObject;   
  
        if (!navAgent.pathPending && navAgent.remainingDistance <= 1
                    && (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f))
        {
            currentWaypoint = ++currentWaypoint % wayList.Count;
            navAgent.SetDestination(wayList[currentWaypoint].position);
        }
    }*/
    void Start()
    {
        #region WayPoint1
        WaypointsContainer1 = wayPoints.transform.GetChild(0).gameObject;       
        wayList1 = new List<Transform>();      
        WaypointsContainer1.GetComponentsInChildren<Transform>(wayList1);
        navAgent1 = GetComponent<NavMeshAgent>();
        navAgent1.SetDestination(wayList1[0].position);
        wayList1.Remove(WaypointsContainer1.transform);
        #endregion
        #region Waypoint2
        WaypointsContainer2 = wayPoints.transform.GetChild(1).gameObject;
        wayList2 = new List<Transform>();
        wayList2.Remove(WaypointsContainer2.transform);
        WaypointsContainer2.GetComponentsInChildren<Transform>(wayList2);        
        navAgent2 = GetComponent<NavMeshAgent>();
        navAgent2.SetDestination(wayList2[0].position);
        #endregion
    }
    void Update()
    {
        isSpotted = GameObject.Find("Surveillance").GetComponent<RepCam>().lastSpotted;
        if (isSpotted > 0)
        {
            if (!navAgent1.pathPending && navAgent1.remainingDistance <= 1
                       && (!navAgent1.hasPath || navAgent1.velocity.sqrMagnitude == 0f))
            {
                currentWaypoint = ++currentWaypoint % wayList1.Count;
                navAgent1.SetDestination(wayList1[currentWaypoint].position);
            }
        }
        if(isSpotted == 0)
        {
            if (!navAgent2.pathPending && navAgent2.remainingDistance <= 1
                       && (!navAgent2.hasPath || navAgent2.velocity.sqrMagnitude == 0f))
            {
                currentWaypoint = ++currentWaypoint % wayList1.Count;
                navAgent2.SetDestination(wayList2[currentWaypoint].position);
            }
        }

       
    }
    /*void Fear()
    {
        int result = 0;
        for (int i = 0; i < hidingPlace.transform.childCount; i++)
        {
            if (Compare(hidingPlace.transform.GetChild(i)) > result)
                result = Compare(hidingPlace.transform.GetChild(i));
        }
    }
    int Compare(Transform place)
    {
        return (Mathf.Abs((int)Mathf.Pow(player.transform.position.x - place.position.x, 2) + (int)Mathf.Pow(player.transform.position.y - place.position.y, 2) + (int)Mathf.Pow(player.transform.position.z - place.position.z, 2)));
    }*/
}
