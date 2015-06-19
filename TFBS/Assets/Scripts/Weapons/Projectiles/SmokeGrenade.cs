public class SmokeGrenade : Projectile
{
    protected override void OnAwake()
    {
        MaxDamage = 0;
        MinDamage = 0;
    }
}
