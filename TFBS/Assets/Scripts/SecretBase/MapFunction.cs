using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapFunction : MonoBehaviour
{
    GameObject shop;
    void Start() //maybe replace with update
    {
        shop = GameObject.Find("Shop");
        if (!PlayerBonus.shopEnable)
        {
            shop.active = false;
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
    }
}
