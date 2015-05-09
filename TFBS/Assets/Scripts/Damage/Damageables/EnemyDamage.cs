public class EnemyDamage : BaseDamageable
{
    protected override void Setup()
    {
        MaxHealthPoints = 100;
    }

    protected override void OnDied()
    {
        base.OnDied();
        DropSpawner.SpawnCube<AmmoDrop>(transform);
    }
}
