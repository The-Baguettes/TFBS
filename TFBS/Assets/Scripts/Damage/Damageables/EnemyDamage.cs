using UnityEngine;

public class EnemyDamage : BaseDamageable
{
    EnemyAI AI;

    protected override void OnStart()
    {
        MaxHealthPoints = 100;
        
        AI = GetComponent<EnemyAI>();
    }

    protected override void OnTakeDamage()
    {
        AI.OnTakeDamage();
    }

    protected override void OnDeath()
    {
        DropSpawner.SpawnCube<AmmoDrop>(transform);
    }
}
