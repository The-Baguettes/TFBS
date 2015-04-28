using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float Speed { get; protected set; }

    public Rigidbody Model { get; protected set; }

    protected float DestroyAfter = 5f;

    float firedAt = -1;

    protected abstract void OnAwake();

    void Awake()
    {
        Model = GetComponent<Rigidbody>();
        OnAwake();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.NoHit)
            return;

        Destroy(gameObject);
    }

    public void OnFire()
    {
        firedAt = Time.timeSinceLevelLoad;
    }

    void Update()
    {
        if (firedAt == -1 || Time.timeSinceLevelLoad - firedAt < DestroyAfter)
            return;

        Destroy(gameObject);
    }
}
