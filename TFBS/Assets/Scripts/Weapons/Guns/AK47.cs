public class AK47 : BaseGun
{
    protected override void Setup()
    {
        ReloadCooldown = 1.2f;
        UseCooldown = .16f;

        FireStrength = 40f;

        MagazineSize = 30;
        MagazineCount = 3;
    }
}
