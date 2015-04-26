using UnityEngine;

public class Drop : MonoBehaviour
{
    public PlayerHealth PlayerHealth;

    void Start()
    {
        tag = Tags.NoHit;
        transform.GetComponent<Collider>().isTrigger = true;
    }

    void Update()
    {
        transform.Rotate(transform.position * Time.deltaTime * 2);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag != Tags.Player)
            return;

        PlayerHealth.currentHealth += 20;

        Destroy(gameObject);
    }
}
