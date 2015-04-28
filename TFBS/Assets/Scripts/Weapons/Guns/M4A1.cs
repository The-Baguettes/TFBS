public class M4A1 : Gun
{
    protected override void OnStart()
    {
        UseCooldown = .16f;

        MagazineSize = 30;
        MagazineCount = 3;
    }
}
