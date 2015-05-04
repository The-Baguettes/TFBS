public class PlayerDamage : BaseDamageable
{
    static int savedHP = 150;

    protected override void Setup()
    {
        MaxHealthPoints = 200;
        HealthPoints = savedHP;
    }

    public void SaveHP()
    {
        savedHP = HealthPoints;
    }
}
