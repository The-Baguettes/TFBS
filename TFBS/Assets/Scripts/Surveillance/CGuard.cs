using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CGuard : MonoBehaviour {

    public GameObject listCamera;
    public GameObject Guards;
	void Start () {
	
	}
	
	void Update () {
        if (GameObject.Find("Surveillance").GetComponent<RepCam>().lastSpotted > 0)
        {
            GameObject camera = listCamera.transform.GetChild(GameObject.Find("Surveillance").GetComponent<RepCam>().nbCam).gameObject;
            for (int i = 0; i < Guards.transform.childCount; i++)
            {
                Guards.transform.GetChild(i).GetComponent<EnemyAI>().WaypointsContainerBis.transform.GetChild(0).transform.position = new Vector3(camera.transform.position.x, 0, camera.transform.position.z);
            }
        }
	}
}
