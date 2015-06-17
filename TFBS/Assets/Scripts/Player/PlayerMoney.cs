using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class PlayerMoney
{
    private static int money;

    public static int Money
    {
        get { return PlayerMoney.money; }
    }

    public static void addMoney(int value)
    {
        money += value;
    }
    public static void useMoney(int value)
    {
        if (!PlayerBonus.noPrice)
        {
            if (PlayerBonus.halfPrice)
                money -= value / 2;
            else
                money -= value;
        }
    }
}
