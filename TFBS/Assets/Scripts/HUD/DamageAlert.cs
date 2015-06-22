using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageAlert : MonoBehaviour
{
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
        if (!NetworkManager.IsMultiPlayer)
            gameobj = GameObject.FindWithTag(Tags.Player);
        else if (NetworkManager.LocalPlayer == null)
            return;
        else
            gameobj = NetworkManager.LocalPlayer;

        playerDamage = gameobj.GetComponent<PlayerDamage>();
        currentHealth = playerDamage.HealthPoints;
        previousHealth = currentHealth;
        damageCD = 0f;

        damaged = false;
        damageImage = GetComponent<Image>();
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
