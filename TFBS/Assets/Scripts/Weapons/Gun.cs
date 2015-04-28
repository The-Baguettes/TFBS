using UnityEngine;

public abstract class Gun : Weapon
{
    public int MagazineSize { get; protected set; }

    public Projectile Projectile;
    public Transform ProjectileSpawn { get; protected set; }

    public AudioClip ReloadClip { get; protected set; }
    public AudioClip ReloadFailClip { get; protected set; }

    public int MagazineCount { get; set; }

    protected abstract void OnStart();

    void Start()
    {
        ProjectileSpawn = transform.FindChild("ProjectileSpawn");

        UseClip = transform.FindChild("FireSound").GetComponent<AudioSource>().clip;
        Transform tmp = transform.FindChild("FireFailSound");
        if (tmp != null)
            UseFailClip = tmp.GetComponent<AudioSource>().clip;

        ReloadClip = transform.FindChild("ReloadSound").GetComponent<AudioSource>().clip;
        tmp = transform.FindChild("ReloadFailSound");
        if (tmp != null)
            ReloadFailClip = tmp.GetComponent<AudioSource>().clip;

        UseCount = -1;

        OnStart();

        if (UseCount == -1)
            UseCount = MagazineSize;
    }

    public override bool IsUsable()
    {
        return UseCount > 0;
    }

    public override void Use()
    {
        Rigidbody body = Instantiate(Projectile.gameObject.GetComponent<Rigidbody>(), ProjectileSpawn.position, ProjectileSpawn.rotation) as Rigidbody;
        Projectile proj = body.GetComponent<Projectile>();
        
        body.velocity = ProjectileSpawn.TransformDirection(0, 0, proj.Speed);
        proj.OnFire();
    }
    
    public void Reload()
    {
        if (UseCount == MagazineSize)
            return;

        if (MagazineCount <= 0)
        {
            if (ReloadFailClip != null)
                AudioSource.PlayClipAtPoint(ReloadFailClip, transform.position);
            return;
        }

        if (ReloadClip != null)
            AudioSource.PlayClipAtPoint(ReloadClip, transform.position);

        MagazineCount--;
        UseCount = MagazineSize;
    }
}
