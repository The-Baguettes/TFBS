﻿public class M4A1 : BaseGun
{
    protected override void OnStart()
    {
        ReloadCooldown = 1f;
        UseCooldown = .16f;

        FireStrength = 50f;

        MagazineSize = 30;
        MagazineCount = 3;
    }
}
