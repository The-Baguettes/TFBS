using UnityEngine;
using System.Diagnostics;
using System.Collections;

public class RepCam : MonoBehaviour {

    public GameObject listCamera;
    [HideInInspector]
    public int nbCam;
    [HideInInspector]
    public int result;
    [HideInInspector]
    public int lastSpotted;

	void Start () {
        result = 0;
        lastSpotted = 0;
	}

    void checkSpotted()
    {
        lastSpotted = 0;
        for (int i = 0; i < listCamera.transform.childCount; i++)
        {
            if(listCamera.transform.GetChild(i).GetComponent<SCamera>().spotted)
            {
                 lastSpotted =  i + 1;
                 nbCam = i;
                 return;
            }
        }
    }	
	void Update () {
        checkSpotted();
	}
}
