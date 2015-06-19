using UnityEngine;
using System.Collections;

public class AssassinationMissions : MonoBehaviour
{
    public GameObject office;

    void Start()
    {
        if (!PlayerBonus.enableAssassinationMission)
        {
            office.active = false;
        }
    }
}
