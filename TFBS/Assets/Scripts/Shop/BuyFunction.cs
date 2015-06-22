using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyFunction : MonoBehaviour
{
    public Button suppressor;
    public Button m4;
    public Button smoke;

    void Start()
    {
        if (PlayerBonus.suppressor)
        {
            suppressor.enabled = false;
            suppressor.GetComponentInChildren<Text>().text = "Bought";
        }
        if (PlayerBonus.m4a1)
        {
            m4.enabled = false;
            m4.GetComponentInChildren<Text>().text = "Bought";
        }
        if (PlayerBonus.smokeLauncher)
        {
            smoke.enabled = false;
            smoke.GetComponentInChildren<Text>().text = "Bought";
        }
    }

    public void Suppressor()
    {
        PlayerBonus.suppressor = true;
        PlayerMoney.useMoney(1000);

        suppressor.enabled = false;
        suppressor.GetComponentInChildren<Text>().text = "Bought";
    }

    public void M4A1()
    {
        PlayerBonus.weaponsAvailable[0] = true;
        PlayerMoney.useMoney(2000);

        m4.enabled = false;
        m4.GetComponentInChildren<Text>().text = "Bought";
    }

    public void Smoke()
    {
        PlayerBonus.weaponsAvailable[2] = true;
        PlayerMoney.useMoney(500);

        smoke.enabled = false;
        smoke.GetComponentInChildren<Text>().text = "Bought";
    }
}
