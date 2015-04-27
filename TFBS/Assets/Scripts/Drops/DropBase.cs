using UnityEngine;

public abstract class DropBase : MonoBehaviour
{
    protected FirePlayer firePlayer;
    protected PlayerHealth playerHealth;

    void Awake()
    {
        tag = Tags.NoHit;
        transform.GetComponent<Collider>().isTrigger = true;

        firePlayer = FindObjectOfType<FirePlayer>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
        transform.Rotate(transform.position * Time.deltaTime * 2);
    }

    protected abstract void OnPickup();

    void OnTriggerEnter(Collider col)
    {
        if (col.tag != Tags.Player)
            return;

        OnPickup();
        Destroy(gameObject);
    }
}
