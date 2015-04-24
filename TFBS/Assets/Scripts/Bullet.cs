using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        GameObject[] nohit = GameObject.FindGameObjectsWithTag(Tags.NoHit);

        Collider col = GetComponent<Collider>();
        for (int i = 0; i < nohit.Length; i++)
            Physics.IgnoreCollision(col, nohit[i].GetComponent<Collider>());
    }

    void OnTriggerEnter()
    {
        Destroy(gameObject);
    }
}
