using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CGuard : MonoBehaviour {

    NavMeshAgent navAgent1;
    List<Transform> wayList1;
    GameObject WaypointsContainer1;
	void Start () {
	
	}
	
	void Update () {
        if (GameObject.Find("Surveillance").GetComponent<RepCam>().lastSpotted > 0)
        {
           
            
        }
	}
}
