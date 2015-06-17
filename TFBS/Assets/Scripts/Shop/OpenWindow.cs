using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpenWindow : MonoBehaviour
{
    public Canvas canvas;

    void Start()
    {
        canvas.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.Player)
        {
            canvas.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.Player)
        {
            canvas.enabled = false;
        }
    }
}
