using UnityEngine;
using System.Collections;

public class DoorAnimation : MonoBehaviour {

    // Smothly open a door
float smooth = 2.0f;
var DoorOpenAngle = 90.0;
private bool open;
private bool enter;

private var defaultRot : Vector3;
private var openRot : Vector3;

function Start(){
defaultRot = transform.eulerAngles;
openRot = new Vector3 (defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
}


function Update ()
{
    if(open)
    {

        transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);

    }
    else
    {
        transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
    }

    if(Input.MouseClick)
    {
        open = !open;
    }
}

    function OnGUI()
        {
           if(enter)
            {
                GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'F' to open the door");
            }
        }
}
