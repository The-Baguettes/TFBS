using UnityEngine;

public abstract class BaseDamageable : BaseComponent
{
    public int HealthPoints { get; protected set; }

    public delegate void HealthPointChangeEventHandler(int value, int delta);

    public event BaseComponent.EventHandler OnDeath;
    public event HealthPointChangeEventHandler OnChangeHealthPoints;

    protected int MaxHealthPoints;

    protected abstract void Setup();

    sealed protected override void OnStart()
    {
        HealthPoints = -1;

        Setup();

        if (HealthPoints == -1)
            HealthPoints = MaxHealthPoints;
    }

    public virtual void AddHealthPoints(int amount)
    {
        HealthPoints += amount;

        if (HealthPoints > MaxHealthPoints)
        {
            amount = HealthPoints - MaxHealthPoints;
            HealthPoints = MaxHealthPoints;
        }
        
        if (OnChangeHealthPoints != null)
            OnChangeHealthPoints(HealthPoints, amount);
    }

    public virtual void RemoveHealthPoints(IDamager damager)
    {
        int delta = (int)Mathf.Lerp(
            damager.MinDamage, damager.MaxDamage,
            5 / Vector3.Distance(transform.position, damager.UsedFrom)
        );

        HealthPoints -= delta;

        if (HealthPoints < 0)
        {
            if (OnDeath != null)
                OnDeath();

            Destroy(gameObject);
        }
        else if (OnChangeHealthPoints != null)
            OnChangeHealthPoints(HealthPoints, delta);
    }
}
