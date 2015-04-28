public class AK47 : Gun
{
    protected override void OnStart()
    {
        ReloadCooldown = 1.2f;
        UseCooldown = .16f;

        MagazineSize = 30;
        MagazineCount = 3;
    }
}
