using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArmorBar : MonoBehaviour
{
    Slider slider;
    PlayerDamage playerDamage;
    GameObject gameobj;

    void Start()
    {
        GameObject player = GameObject.FindWithTag(Tags.Player);
        playerDamage = player.GetComponent<PlayerDamage>();

        gameobj = GameObject.Find("ArmorBar");
        slider = gameobj.GetComponent<Slider>();
    }


    void Armor()
    {
        if (playerDamage.HealthPoints > 100)
        {
            slider.value = playerDamage.HealthPoints - 100;
        }
        else
        {
            slider.value = 0f;
        }
    }

    void Update()
    {
        Armor();
    }

}
