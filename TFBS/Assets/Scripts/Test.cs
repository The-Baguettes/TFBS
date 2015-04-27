using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{
    float smooth = 2.0f;
    private bool open;
    private Vector3 defaultRot;
    private Vector3 openRot;

	void Start ()
    {
        defaultRot = transform.eulerAngles;
        openRot = new Vector3(defaultRot.x - 90.0f, defaultRot.y - 90f, defaultRot.z);
	}
	
	void Update () 
    {
        if (Input.GetKeyDown("f") )
            open = !open;

        open_or_close(open);
	}

    void open_or_close(bool open)
    {
        if (open)
        {
            
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
        }
        else
        {
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
        }
    }
}
