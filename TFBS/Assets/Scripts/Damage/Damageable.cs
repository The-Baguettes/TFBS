using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    public int HealthPoints { get; protected set; }

    protected int MaxHealthPoints;

    protected abstract void OnStart();

    protected virtual void OnDeath()
    { }

    protected virtual void OnTakeDamage()
    { }

    protected void Start()
    {
        HealthPoints = -1;

        OnStart();

        if (HealthPoints == -1)
            HealthPoints = MaxHealthPoints;
    }

    public virtual void Heal(int amount)
    {
        HealthPoints += amount;

        if (HealthPoints > MaxHealthPoints)
            HealthPoints = MaxHealthPoints;
    }

    public virtual void TakeDamage(IDamager damager)
    {
        HealthPoints -= (int)Mathf.Lerp(
            damager.MinDamage, damager.MaxDamage,
            5 / Vector3.Distance(transform.position, damager.UsedFrom)
        );

        if (HealthPoints < 0)
        {
            OnDeath();
            Destroy(gameObject);
        }
        else
            OnTakeDamage();
    }
}
