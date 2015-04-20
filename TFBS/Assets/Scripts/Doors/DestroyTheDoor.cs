using UnityEngine;
using System.Collections;

public class DestroyTheDoor : MonoBehaviour {

    public int durability;
    Object parent;
    
    void Start()
    {
        parent = this.transform.parent.gameObject;
    }

    void Update()
    {
        if (durability == 0)
        {
            //play an animation
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
