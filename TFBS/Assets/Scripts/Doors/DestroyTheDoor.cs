using UnityEngine;
using System.Collections;

public class DestroyTheDoor : MonoBehaviour {

    public int durability;
    public GameObject body;
    public Transform prefab;
    Object parent;

    void Start()
    {
        parent = this.transform.parent.gameObject;
    }

    void Update()
    {
        if (durability == 0)
        {
            Instantiate(prefab, body.transform.position, Quaternion.identity);
            GameObject.Destroy(parent);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            durability--;
        }
    }
}
