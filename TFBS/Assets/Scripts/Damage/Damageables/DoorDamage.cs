using UnityEngine;

public class DoorDamage : BaseDamageable
{
    public Transform DestroyEffect;

    protected override void Setup()
    {
        MaxHealthPoints = 20;
    }

    protected override void OnDied()
    {
        base.OnDied();
        Destroy(transform.parent.gameObject);
        Instantiate(DestroyEffect, transform.position, Quaternion.identity);
    }
}
