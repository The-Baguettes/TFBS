using UnityEngine;
using System.Diagnostics;
using System.Collections;

public class RepCam : MonoBehaviour {

    public GameObject listCamera;
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
        for (int i = 0; i < listCamera.transform.childCount; i++)
        {
            if(listCamera.transform.GetChild(i).GetComponent<SCamera>().spotted)
            {
                lastSpotted =  i + 1;
            }
        }
    }	
	void Update () {
        checkSpotted();
	}
}
