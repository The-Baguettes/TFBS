using UnityEngine;

public abstract class DropBase : MonoBehaviour
{
    protected PlayerHealth playerHealth;
    protected WeaponManager weaponManager;

    abstract protected Color32 color { get; }

    void Awake()
    {
        tag = Tags.NoHit;
        transform.GetComponent<Collider>().isTrigger = true;

        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        GetComponent<Renderer>().material.color = color;

        playerHealth = FindObjectOfType<PlayerHealth>();
        weaponManager = FindObjectOfType<WeaponManager>();
    }

    void Update()
    {
        transform.Rotate(transform.position * Time.deltaTime * 2);
    }

    protected abstract bool Pickup();

    void OnTriggerEnter(Collider col)
    {
        if (col.tag != Tags.Player)
            return;

        if (Pickup())
            Destroy(gameObject);
    }
}
