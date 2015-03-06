using UnityEngine;
using System.Collections;

public class FireBullet : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 20;
    public float ammo = 10;
    private GameObject player;
    float MinDistance = 1f;
    float MaxDistance = 50f;
    float elapsedtime = 0f;

    void Start() 
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player);
    }
    
    void Update()
    {
        elapsedtime += Time.deltaTime;
        if (ammo > 0 && elapsedtime >1.0f)
        {
            if (Vector3.Distance(transform.position, player.transform.position) >= MinDistance && Vector3.Distance(transform.position, player.transform.position) <= MaxDistance )
            {
                transform.LookAt(player.transform.position);
                elapsedtime = 0;
                Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
                instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
                AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip,transform.position);
                ammo = ammo - 1f;
            }
        }
    }


}

