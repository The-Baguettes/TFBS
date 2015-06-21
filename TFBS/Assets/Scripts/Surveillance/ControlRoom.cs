using System.Collections.Generic;
using UnityEngine;

public class ControlRoom : BaseComponent
{
    public Transform CameraContainer;

    bool isPlayerNear;

    int active;
    List<Camera> ListCamera;

    protected void Awake()
    {
        ListCamera = new List<Camera>();
        CameraContainer.GetComponentsInChildren<Camera>(ListCamera);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.Player)
            isPlayerNear = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == Tags.Player)
            isPlayerNear = false;
    }

    void Update()
    {
        if (!isPlayerNear)
            return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            ListCamera[active].enabled = false;
            active = ++active % ListCamera.Count;
            ListCamera[active].enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.E))
            ListCamera[active].enabled = false;
    }
}
