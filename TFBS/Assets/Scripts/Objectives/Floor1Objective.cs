using UnityEngine;

public class Floor1Objective : MonoBehaviour
{
    HUD hud;

    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
        hud.SetObjective("Clear the level");
    }

    void OnTriggerEnter(Collider checkpointcol)
    {
        if (checkpointcol.tag == Tags.Player)
            hud.SetObjective(null);
    }
}
