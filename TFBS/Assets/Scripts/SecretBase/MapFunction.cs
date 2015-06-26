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
            shop.SetActive(false);
        }
        if (PlayerMoney.Money < 250000)
        {
            street.SetActive(false);
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
            shop.SetActive(true);
        }
        if (PlayerMoney.Money >= 250000)
        {
            street.SetActive(true);
        }
    }
}
