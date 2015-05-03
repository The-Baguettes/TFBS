using UnityEngine;

public class StairwayObjective : MonoBehaviour
{
    HUD hud;

    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
        hud.SetObjective("Find the secret room");
    }

    void OnTriggerEnter(Collider checkpointcol)
    {
        if (checkpointcol.tag == Tags.Player)
            hud.SetObjective(null);
    }
}
