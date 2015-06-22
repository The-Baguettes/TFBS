public class M4A1 : BaseGun
{
    protected override void Setup()
    {
        ReloadCooldown = 1f;
        UseCooldown = .16f;

        FireStrength = 60f;

        MagazineSize = 30;
        MagazineCount = 3;
    }
}
