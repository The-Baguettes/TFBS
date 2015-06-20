using UnityEngine;
using System.Collections.Generic;

public class CivilAI : MonoBehaviour
{
    public GameObject wayPoints;
    int currentWaypoint;
    #region NavAgent
    NavMeshAgent navAgent1;
    NavMeshAgent navAgent2;
    NavMeshAgent navAgent3;
    NavMeshAgent navAgent4;
    NavMeshAgent navAgent5;
    #endregion
    #region Waylists
    List<Transform> wayList1;
    List<Transform> wayList2;
    List<Transform> wayList3;
    List<Transform> wayList4;
    List<Transform> wayList5;
    #endregion
    #region Waypoints
    GameObject WaypointsContainer1; //Spotted1
    GameObject WaypointsContainer2; //Spotted2
    GameObject WaypointsContainer3; //Spotted3
    GameObject WaypointsContainer4; //Spotted4
    GameObject WaypointsContainer5; //Normal
    #endregion
    public GameObject hidingPlace;
    public GameObject player;    
    [HideInInspector]
    public int isSpotted;
    [HideInInspector]
    public int hideRoom;
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
        #region SetWaypointsContainers
        WaypointsContainer1 = wayPoints.transform.GetChild(0).gameObject;
        WaypointsContainer2 = wayPoints.transform.GetChild(1).gameObject;
        WaypointsContainer3 = wayPoints.transform.GetChild(2).gameObject;
        WaypointsContainer4 = wayPoints.transform.GetChild(3).gameObject;
        WaypointsContainer5 = wayPoints.transform.GetChild(4).gameObject;
        #endregion
        #region SetWayLists
        wayList1 = new List<Transform>();
        wayList2 = new List<Transform>();
        wayList3 = new List<Transform>();
        wayList4 = new List<Transform>();
        wayList5 = new List<Transform>();
        #endregion
        #region WPCGetCompotnents
        WaypointsContainer1.GetComponentsInChildren<Transform>(wayList1);
        WaypointsContainer2.GetComponentsInChildren<Transform>(wayList2);
        WaypointsContainer3.GetComponentsInChildren<Transform>(wayList3);
        WaypointsContainer4.GetComponentsInChildren<Transform>(wayList4);
        WaypointsContainer5.GetComponentsInChildren<Transform>(wayList5);
        #endregion
        #region wayListRemove
        wayList1.Remove(WaypointsContainer1.transform);
        wayList2.Remove(WaypointsContainer2.transform);
        wayList3.Remove(WaypointsContainer3.transform);
        wayList4.Remove(WaypointsContainer4.transform); 
        wayList5.Remove(WaypointsContainer5.transform);
        #endregion
        #region navAgents
        navAgent1 = GetComponent<NavMeshAgent>();
        navAgent1.SetDestination(wayList1[0].position);
        navAgent2 = GetComponent<NavMeshAgent>();
        navAgent2.SetDestination(wayList2[0].position);
        navAgent3 = GetComponent<NavMeshAgent>();
        navAgent3.SetDestination(wayList3[0].position);
        navAgent4 = GetComponent<NavMeshAgent>();
        navAgent4.SetDestination(wayList4[0].position);
        navAgent5 = GetComponent<NavMeshAgent>();
        navAgent5.SetDestination(wayList5[0].position);
        #endregion
        #region SetDestination
        navAgent1.SetDestination(wayList1[0].position);
        navAgent2.SetDestination(wayList2[0].position);
        navAgent3.SetDestination(wayList3[0].position);
        navAgent4.SetDestination(wayList4[0].position);
        navAgent5.SetDestination(wayList5[0].position);
        #endregion
    }
    void Update()
    {        
        isSpotted = GameObject.Find("Surveillance").GetComponent<RepCam>().lastSpotted;
        hideRoom = Fear();
        if (isSpotted > 0)
        {
            switch (hideRoom)
            {
                case 1 :
                    if (!navAgent1.pathPending && navAgent1.remainingDistance <= 1
                      && (!navAgent1.hasPath || navAgent1.velocity.sqrMagnitude == 0f))
                    {
                        currentWaypoint = ++currentWaypoint % wayList1.Count;
                        navAgent1.SetDestination(wayList1[currentWaypoint].position);
                    }
                    break;
                case 2:
                    if (!navAgent2.pathPending && navAgent2.remainingDistance <= 1
                      && (!navAgent2.hasPath || navAgent2.velocity.sqrMagnitude == 0f))
                    {
                        currentWaypoint = ++currentWaypoint % wayList2.Count;
                        navAgent2.SetDestination(wayList2[currentWaypoint].position);
                    }
                    break;
                case 3:
                    if (!navAgent3.pathPending && navAgent3.remainingDistance <= 1
                      && (!navAgent3.hasPath || navAgent3.velocity.sqrMagnitude == 0f))
                    {
                        currentWaypoint = ++currentWaypoint % wayList3.Count;
                        navAgent3.SetDestination(wayList3[currentWaypoint].position);
                    }
                    break;
                case 4:
                    if (!navAgent4.pathPending && navAgent4.remainingDistance <= 1
                      && (!navAgent4.hasPath || navAgent4.velocity.sqrMagnitude == 0f))
                    {
                        currentWaypoint = ++currentWaypoint % wayList4.Count;
                        navAgent4.SetDestination(wayList4[currentWaypoint].position);
                    }
                    break;
            }
        }
        else
        {
            if (!navAgent5.pathPending && navAgent5.remainingDistance <= 1
                       && (!navAgent5.hasPath || navAgent5.velocity.sqrMagnitude == 0f))
            {
                currentWaypoint = ++currentWaypoint % wayList5.Count;
                navAgent5.SetDestination(wayList5[currentWaypoint].position);
            }
        }
    }
    int Fear()
    {
        int last = 0;
        int room = 0;
        for (int i = 0; i < hidingPlace.transform.childCount; i++)
        {
            if (Compare(hidingPlace.transform.GetChild(i)) > last)
            {
                last = Compare(hidingPlace.transform.GetChild(i));
                room = i;
            }
        }
        return room+1;  
    }
    int Compare(Transform place)
    {
        return (Mathf.Abs((int)Mathf.Pow(player.transform.position.x - place.position.x, 2) + (int)Mathf.Pow(player.transform.position.y - place.position.y, 2) + (int)Mathf.Pow(player.transform.position.z - place.position.z, 2)));
    }
}
