public class GrenadeLauncher : BaseGun
{
    protected override void Setup()
    {
        ReloadCooldown = 4f;
        UseCooldown = .16f;

        FireStrength = 100f;

        MagazineSize = 4;
        MagazineCount = 1;
    }
}