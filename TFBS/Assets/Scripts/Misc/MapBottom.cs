using UnityEngine;

public class MapBottom : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        BaseDamageable damageable = col.GetComponent<BaseDamageable>();

        if (damageable != null)
            damageable.Kill();

        Destroy(col.gameObject);
    }
}
