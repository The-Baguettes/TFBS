using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageAlert : MonoBehaviour
{
    GameObject damageAlert;
    Image damageImage;
    Color color;
    Color normalColor;
    Color damagedColor;
    bool damaged;

    PlayerDamage playerDamage;
    GameObject gameobj;
    int currentHealth;
    int previousHealth;
    float damageCD;

    void Start()
    {
        gameobj = GameObject.FindWithTag(Tags.Player);
        playerDamage = gameobj.GetComponent<PlayerDamage>();
        currentHealth = playerDamage.HealthPoints;
        previousHealth = currentHealth;
        damageCD = 0f;

        damaged = false;
        damageAlert = GameObject.Find("DamageAlert");
        damageImage = damageAlert.GetComponent<Image>();
        color = damageImage.color;
        damagedColor = color;
        color.a = 0f;
        normalColor = color;
    }

    void Update()
    {
        currentHealth = playerDamage.HealthPoints;
        //avoid multiple flash in an short interval
        if (currentHealth < previousHealth && Time.time > damageCD)
        {
            damaged = true;
            damageCD = Time.time + 0.2f;
        }
        else
            if (Time.time > damageCD)
            {
                damaged = false;
            }

        if (damaged)
        {
            //play the damage sound or an "arrrggh"
            color = damagedColor;
        }
        else
        {
            color = normalColor;
        }
        damageImage.color = color;
        previousHealth = playerDamage.HealthPoints;
    }

}
