using System;
using UnityEngine;

public class PlayerDamage : BaseDamageable
{
    protected override void Setup()
    {
        MaxHealthPoints = 200;
        HealthPoints = 150;
    }
}
