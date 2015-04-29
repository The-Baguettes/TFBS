using UnityEngine;

public interface IDamager
{
    int MaxDamage { get; }
    int MinDamage { get; }

    Vector3 UsedFrom { get; }
}
