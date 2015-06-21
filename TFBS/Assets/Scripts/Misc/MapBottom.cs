using UnityEngine;

public class MapBottom : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag != Tags.Player)
            return;

        col.GetComponent<BaseDamageable>().Kill();
    }
}
