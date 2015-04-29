using UnityEngine;
using System.Collections;

public class ElevatorDoor : MonoBehaviour
{
    bool playerIsNear = false;
  //  const float smooth = 10.0f;
    float lerpPosition = 0.0f;
    public int a;
    Vector3 Vopen;
    Vector3 Vclose;
    private Vector3 velocity = Vector3.zero;
	void Start ()
    {
        Vclose = transform.position;
        Vopen  = new Vector3(Vclose.x, Vclose.y, Vclose.z + a);
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


	void Update () 
    {
        if (playerIsNear)
        {
            if (transform.position == Vopen)
                lerpPosition = 0.0f;
            else
            {
                transform.position = Vector3.Lerp(Vclose, Vopen, lerpPosition);
            }
        }
        else
        {           
            if (transform.position == Vclose)
                lerpPosition = 0.0f;
            else 
            {
               transform.position = Vector3.Lerp(Vopen, Vclose, lerpPosition);
            }
        }
        lerpPosition += Time.deltaTime;
    }

   
    
}

