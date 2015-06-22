using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class PlayerBonus
{
    public static bool doubleHostage;
    public static bool deadHostage;
    public static bool hardHostage;
    public static bool shopEnable;
    public static bool halfPrice;
    public static bool noPrice;

    public static bool recruit;

    public static bool scientistAlive;
    public static bool enableAssassinationMission;

    public static bool hostageFollowing;

    public static bool suppressor;

    public static bool ak47;
    public static bool m4a1;
    public static bool smokeLauncher;

    public static bool[] weaponsAvailable =
    {
        m4a1 = false,
        ak47 = true,
        smokeLauncher = false,
    };
}

