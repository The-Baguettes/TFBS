using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float UseCooldown { get; protected set; }
    public int UsesLeft { get; set; }

    public AudioClip UseClip { get; protected set; }
    public AudioClip UseFailClip { get; protected set; }

    public abstract bool IsUsable();
    public abstract void Use();
}
