using UnityEngine;

public abstract class BaseGun : BaseWeapon
{
    public int MagazineSize { get; protected set; }
    public float ReloadCooldown { get; protected set; }

    public Projectile Projectile;
    public Transform ProjectileSpawn { get; protected set; }

    public AudioClip ReloadClip { get; protected set; }
    public AudioClip ReloadFailClip { get; protected set; }

    public int MagazineCount { get; set; }

    protected GameObject Silencer;
    protected AudioClip FireSilencedClip;

    /// <summary>
    /// Speed of a the projectile after being fired.
    /// </summary>
    protected float FireStrength;

    protected abstract void Setup();

    HUD hud;
    protected override void OnStart()
    {
        hud = FindObjectOfType<HUD>();

        ProjectileSpawn = transform.FindChild("ProjectileSpawn");

        UseClip = transform.FindChild("FireSound").GetComponent<AudioSource>().clip;
        Transform tmp = transform.FindChild("FireFailSound");
        if (tmp != null)
            UseFailClip = tmp.GetComponent<AudioSource>().clip;

        ReloadClip = transform.FindChild("ReloadSound").GetComponent<AudioSource>().clip;
        tmp = transform.FindChild("ReloadFailSound");
        if (tmp != null)
            ReloadFailClip = tmp.GetComponent<AudioSource>().clip;

        tmp = transform.FindChild("Silencer");
        if (tmp != null)
        {
            Silencer = tmp.gameObject;

            tmp = transform.FindChild("FireSilencedSound");
            if (tmp != null)
                FireSilencedClip = tmp.GetComponent<AudioSource>().clip;
        }

        UsesLeft = -1;

        Setup();

        if (UsesLeft == -1)
            UsesLeft = MagazineSize;
    }

    protected override void OnUse(Transform target)
    {
        // TODO: Aim at target
        Projectile proj = Instantiate(Projectile, ProjectileSpawn.position, ProjectileSpawn.rotation) as Projectile;
        Rigidbody body = proj.GetComponent<Rigidbody>();
        if(target!=null)
        proj.transform.LookAt(target);
        body.velocity = ProjectileSpawn.TransformDirection(0, 0, FireStrength);
        proj.OnFire(ProjectileSpawn.position);
    }

    public void Reload()
    {
        if (UsesLeft == MagazineSize || !CoolDownOver())
            return;

        if (MagazineCount <= 0)
        {
            if (ReloadFailClip != null)
                AudioSource.PlayClipAtPoint(ReloadFailClip, transform.position);
            return;
        }

        if (ReloadClip != null)
            AudioSource.PlayClipAtPoint(ReloadClip, transform.position);

        NextUseTime = Time.time + ReloadCooldown;
        MagazineCount--;
        UsesLeft = MagazineSize;

        hud.playerWeaponManager_ActiveUsed(); // TODO: Proper event
    }

    public void ToggleSilencer()
    {
        if (Silencer == null)
            return;

        Silencer.SetActive(!Silencer.activeSelf);

        AudioClip tmp = UseClip;
        UseClip = FireSilencedClip;
        FireSilencedClip = tmp;
    }
}
