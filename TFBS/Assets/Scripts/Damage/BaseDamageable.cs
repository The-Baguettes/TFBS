using UnityEngine;

public abstract class BaseDamageable : BaseComponent
{
    public int HealthPoints { get; protected set; }

    public delegate void HealthPointChangeEventHandler(int value, int delta);

    public event BaseComponent.EventHandler Died;
    public event HealthPointChangeEventHandler HealthPointsChanged;

    protected int MaxHealthPoints;

    protected abstract void Setup();

    sealed protected override void Start()
    {
        Reset();
        base.Start();
    }

    public virtual void AddHealthPoints(int amount)
    {
        HealthPoints += amount;

        if (HealthPoints > MaxHealthPoints)
        {
            amount = HealthPoints - MaxHealthPoints;
            HealthPoints = MaxHealthPoints;
        }

        OnHealthPointsChanged(amount);
    }

    public void Kill()
    {
        HealthPoints = -1;
        OnDied();
    }

    public virtual void RemoveHealthPoints(IDamager damager)
    {
        int delta = (int)Mathf.Lerp(
            damager.MinDamage, damager.MaxDamage,
            5 / Vector3.Distance(transform.position, damager.UsedFrom)
        );

        HealthPoints -= delta;

        if (HealthPoints < 0)
            OnDied();
        else
            OnHealthPointsChanged(delta);
    }

    public void Reset()
    {
        HealthPoints = -1;

        Setup();

        if (HealthPoints == -1)
            HealthPoints = MaxHealthPoints;
    }

    protected virtual void OnHealthPointsChanged(int delta)
    {
        if (HealthPointsChanged != null)
            HealthPointsChanged(HealthPoints, delta);
    }

    protected virtual void OnDied()
    {
        if (Died != null)
            Died();

        Destroy(gameObject);
    }
}
