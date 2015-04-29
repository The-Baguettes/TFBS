using UnityEngine;

public abstract class Projectile : MonoBehaviour
{

    public Rigidbody Model { get; protected set; }

    protected float DestroyAfter = 5f;

    float destroyTime = float.PositiveInfinity;

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
        Destroy(gameObject);
    }

    public void OnFire()
    {
        destroyTime = Time.timeSinceLevelLoad + DestroyAfter;
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad < destroyTime)
            return;

        Destroy(gameObject);
    }
}
