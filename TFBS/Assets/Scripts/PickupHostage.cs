using UnityEngine;
using System.Collections;

public class PickupHostage : MonoBehaviour
{
    public Hostage hostage;

    void OnTriggerEnter(Collider Other) 
    {
        if (Other.tag == Tags.Player)
            hostage.Follow(Other.transform);
    }
}