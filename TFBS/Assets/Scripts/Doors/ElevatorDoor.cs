using UnityEngine;
using System.Collections;

public class ElevatorDoor : MonoBehaviour {

  
    bool playerIsNear = false;
    const float smooth = 2.0f;
    public float a;
    public GameObject Door;
    Vector3 Vopen;
    Vector3 Vclose;
	void Start ()
    {
        Vclose = Door.transform.position;
        Vopen = new Vector3(Vclose.x + a, Vclose.y, Vclose.z);
	}
	
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == Tags.Player)         
            playerIsNear = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == Tags.Player)
            playerIsNear = false;        
    }

    void Open()
    {
        transform.eulerAngles = Vector3.Lerp(Door.transform.position, Vopen, Time.deltaTime * 2.0f);
        Door.transform.position = Vopen;
    }

    void Close()
    {
        transform.eulerAngles = Vector3.Lerp(Door.transform.position, Vclose, Time.deltaTime * 2.0f);
        Door.transform.position = Vclose;
    }

	void Update () 
    {
        if (playerIsNear)
            Open();
        if (!playerIsNear)
            Close();
	}
}
