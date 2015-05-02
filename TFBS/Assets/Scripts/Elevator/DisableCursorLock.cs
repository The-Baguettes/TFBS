using UnityEngine;
using System.Collections;

public class DisableCursorLock : MonoBehaviour
{
    bool visible;
    bool contact;

    void Start()
    {
        contact = false;
        visible = false;
    }

    void SetCursorState()
    {
        Cursor.visible = visible;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.Player)
        {
            Cursor.lockState = CursorLockMode.None;
            visible = true;
            contact = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.Player)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            contact = false;
        }
    }

    void Update()
    {
        if (contact)
        {
            Cursor.visible = visible;
        }
    }
}
