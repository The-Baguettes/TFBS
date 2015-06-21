using UnityEngine;

public abstract class Projectile : MonoBehaviour, IDamager
{
    #region IDamager
    public int MaxDamage { get; protected set; }
    public int MinDamage { get; protected set; }
    public Vector3 UsedFrom { get; protected set; }
    #endregion

    public Rigidbody Model { get; protected set; }

    protected float DestroyAfter = 5;

    protected abstract void OnAwake();

    void Awake()
    {
        Model = GetComponent<Rigidbody>();
        OnAwake();
    }

    void Start()
    {
        GameObject[] nohit = GameObject.FindGameObjectsWithTag(Tags.NoHit);

        Collider col = GetComponent<Collider>();
        for (int i = 0; i < nohit.Length; i++)
            Physics.IgnoreCollision(col, nohit[i].GetComponent<Collider>());
    }

    void OnTriggerEnter(Collider col)
    {
        BaseDamageable dam = col.GetComponent<BaseDamageable>();
        if (dam != null)
            dam.RemoveHealthPoints(this);

        Destroy(gameObject);
    }

    public void OnFire(Vector3 spawnPoint)
    {
        UsedFrom = spawnPoint;

        Destroy(gameObject, DestroyAfter);
    }
}
