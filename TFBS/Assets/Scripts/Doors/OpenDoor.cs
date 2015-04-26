using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    const float smooth = 2.0f;
    readonly Rect uiRect = new Rect(Screen.width / 2 - 75, Screen.height - 100, 200, 30);

    public float DoorOpenAngle = 90.0f;

    bool open;
    bool playerIsNear;
    bool botIsNear;

    // public Object door_handle;
    Vector3 closedRot;
    Vector3 openRot;

    void Start()
    {
        closedRot = transform.eulerAngles;
        openRot = new Vector3(closedRot.x, closedRot.y - DoorOpenAngle, closedRot.z);
    }

    void Update()
    {
        if (botIsNear)
            open = true;
        else if (playerIsNear && Input.GetKeyDown("f"))
            open = !open;

        Animate();
    }

    void OnGUI()
    {
        if (!playerIsNear)
            return;

        if (open)
            GUI.Label(uiRect, "Press 'F' to close the door");
        else
            GUI.Label(uiRect, "Press 'F' to open the door");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == Tags.Player)
            playerIsNear = true;
        else if (col.gameObject.tag == Tags.Enemy)
            botIsNear = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == Tags.Player)
            playerIsNear = false;
        else if (col.gameObject.tag == Tags.Enemy)
        {
            botIsNear = false;
            open = false;
        }
    }

    void Animate()
    {
        transform.eulerAngles = Vector3.Slerp(
            transform.eulerAngles,
            open ? openRot : closedRot,
            Time.deltaTime * smooth
        );
    }
}
