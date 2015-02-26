using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    float smooth = 2.0f;
    float DoorOpenAngle = 90.0f;

    bool open;

    Vector3 defaultRot;
    Vector3 openRot;

    public void Start()
    {
        defaultRot = transform.eulerAngles;
        openRot = new Vector3(defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
    }

    public void Update()
    {
        Vector3 rot = open ? openRot : defaultRot ;
        transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, rot, Time.deltaTime * smooth);
    }

    void OnMouseEnter()
    {
        open = !open;
    }
}
