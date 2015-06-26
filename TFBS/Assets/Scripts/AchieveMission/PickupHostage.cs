using UnityEngine;
using System.Collections;

public class PickupHostage : MonoBehaviour
{
    public bool hard;
    public Hostage hostage;
    new public GameObject light;
    public GameObject light2;

    HUD hud;

    void Start()
    {
        light2.GetComponent<Light>().enabled = false;
        hud = GameObject.FindObjectOfType<HUD>();
    }

    void OnTriggerEnter(Collider Other) 
    {
        if (Other.tag == Tags.Player)
        {
            hud.ObjectiveText.text = "Lead the hostage to the elevator";
            hostage.Follow(Other.transform);
            light.GetComponent<Light>().enabled = false;
            light2.GetComponent<Light>().enabled = true;
            PlayerBonus.hostageFollowing = true;
            PlayerBonus.hardHostage = hard;
        }
    }
}