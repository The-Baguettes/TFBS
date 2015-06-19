public class SmokeLauncher : BaseGun
{
    protected override void Setup()
    {
        ReloadCooldown = 0f;
        UseCooldown = 2.0f;

        FireStrength =0f;

        MagazineSize = 1;
        MagazineCount = 1;
    }
}