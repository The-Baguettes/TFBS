public class Pistol : BaseGun
{
        protected override void Setup()
    {
        ReloadCooldown = 1.5f;
        UseCooldown = .3f;

        FireStrength = 30f;

        MagazineSize = 8;
        MagazineCount = 5;
    }
}
