using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    public float UseCooldown { get; protected set; }

    public float NextUseTime { get; set; }
    public int UsesLeft { get; set; }

    public AudioClip UseClip { get; protected set; }
    public AudioClip UseFailClip { get; protected set; }

    protected abstract void OnUse(Transform target);

    protected virtual bool AbortUse()
    {
        return !CoolDownOver();
    }

    protected virtual bool CoolDownOver()
    {
        return Time.time >= NextUseTime;
    }

    public virtual bool IsUsable()
    {
        return UsesLeft > 0;
    }

    public void Use(Transform target)
    {
        if (AbortUse())
            return;

        if (!IsUsable())
        {
            if (UseFailClip != null)
                AudioSource.PlayClipAtPoint(UseFailClip, transform.position);
            return;
        }

        NextUseTime = Time.time + UseCooldown;
        UsesLeft--;
        OnUse(target);

        if (UseClip != null)
            AudioSource.PlayClipAtPoint(UseClip, transform.position);
    }
}
