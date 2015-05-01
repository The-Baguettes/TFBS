public class EnemyDamage : BaseDamageable
{
    protected override void Setup()
    {
        MaxHealthPoints = 100;

        OnDeath += EnemyDamage_OnDeath;
    }

    void EnemyDamage_OnDeath()
    {
        DropSpawner.SpawnCube<AmmoDrop>(transform);
    }
}
