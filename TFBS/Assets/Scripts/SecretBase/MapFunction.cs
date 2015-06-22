using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapFunction : MonoBehaviour
{
    GameObject shop;
    GameObject street;
    void Start() //maybe replace with update
    {
        shop = GameObject.Find("Shop");
        street = GameObject.Find("Street");
        if (!PlayerBonus.shopEnable)
        {
            shop.active = false;
        }
        if (PlayerMoney.Money < 250000)
        {
            street.active = false;
        }
    }

    public void load(int scene)
    {
        SceneManager.LoadScene((Scene)scene);
    }

    void Update()
    {
        if (PlayerBonus.shopEnable)
        {
            shop.active = true;
        }
        if (PlayerMoney.Money >= 250000)
        {
            street.active = true;
        }
    }
}
