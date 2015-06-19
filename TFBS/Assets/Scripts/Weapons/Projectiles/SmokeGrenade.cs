using UnityEngine;

public class SmokeGrenade : Projectile
{
    public Transform Smoke;
    

    protected override void OnAwake()
    {
        MaxDamage = 0;
        MinDamage = 0;

        
    }
    void OnTriggerEnter(Collider col) 
    {
        Instantiate(Smoke, transform.position, new Quaternion());
        Destroy(gameObject);
    }
}
