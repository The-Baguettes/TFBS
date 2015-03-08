using UnityEngine;
using System.Collections;

public class FireBullet : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 20;
    public float ammo = 30;
    public int magasine = 4;
    GameObject player;
    float elapsedtime = 0f;
    RaycastHit hit;
    void Start() 
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player);
    }
    
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        elapsedtime += Time.deltaTime;
        if (ammo > 0 && elapsedtime >0.2f &&(Physics.Raycast(transform.position, forward, out hit) && hit.collider.tag == Tags.Player))
        {
                transform.LookAt(player.transform.position);
                elapsedtime = 0;
                Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
                instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
                AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip,transform.position);
                ammo = ammo - 1f;
            
        }
        if (ammo == 0 && elapsedtime >2.5)
        {
            elapsedtime = 0;
            ammo = 10;
            magasine-=1;
        }
       
    }


}

