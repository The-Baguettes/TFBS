using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    Slider slider;
    PlayerDamage playerDamage;
    GameObject gameobj;

    void Start()
    {
        GameObject player = GameObject.FindWithTag(Tags.Player);
        playerDamage = player.GetComponent<PlayerDamage>();

        gameobj = GameObject.Find("HealthBar");
        slider = gameobj.GetComponent<Slider>();
    }

    void Health()
    {
        if (playerDamage.HealthPoints <= 0)
        {
            slider.value = 0f;
        }
        else
        {
            if (playerDamage.HealthPoints > 100)
            {
                slider.value = 100;
            }
            else
            {
                slider.value = playerDamage.HealthPoints;
            }
        }
    }



    void Update()
    {
        gameobj = GameObject.Find("HealthBar");
        slider = gameobj.GetComponent<Slider>();
        Health();
    }

}
