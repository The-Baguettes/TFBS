public class Bullet : Projectile
{
    protected override void OnAwake()
    {
        MaxDamage = 50;
        MinDamage = 20;
    }
}
