using UnityEngine;

public class GameObjective : MonoBehaviour
{
    HUD hud;

    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
        hud.SetObjective("Find the elevator");
    }

    void OnTriggerEnter(Collider checkpointcol)
    {
        if (checkpointcol.tag == Tags.Player)
            hud.SetObjective(null);
    }
}
