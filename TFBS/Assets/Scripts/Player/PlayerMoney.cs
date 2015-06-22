using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class PlayerMoney
{
    public static int Money;

    public static void useMoney(int value)
    {
        if (!PlayerBonus.noPrice)
        {
            if (PlayerBonus.halfPrice)
                Money -= value / 2;
            else
                Money -= value;
        }
    }
}
