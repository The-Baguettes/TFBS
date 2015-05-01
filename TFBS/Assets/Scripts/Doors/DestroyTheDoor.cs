using UnityEngine;

public class DestroyTheDoor : MonoBehaviour
{
    public Transform DestroyEffect;
    
    int durability = 2;

    void OnTriggerEnter(Collider col)
    {
        print(col.tag);
        if (col.tag != Tags.Bullet)
            return;

        durability--;
        
        if (durability < 0)
        {
            Instantiate(DestroyEffect, transform.position, Quaternion.identity);
            GameObject.Destroy(transform.parent.gameObject);
        }
    }
}
