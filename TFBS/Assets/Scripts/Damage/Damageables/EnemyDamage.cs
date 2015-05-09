public class EnemyDamage : BaseDamageable
{
    protected override void Setup()
    {
        MaxHealthPoints = 100;

        Died += EnemyDamage_OnDeath;
    }

    void EnemyDamage_OnDeath()
    {
        DropSpawner.SpawnCube<AmmoDrop>(transform);
    }
}
