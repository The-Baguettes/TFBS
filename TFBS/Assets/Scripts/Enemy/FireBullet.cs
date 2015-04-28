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
    bool insight = false;
    void Start() 
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player);
    }
    
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.right);
        elapsedtime += Time.deltaTime;
        //Debug.Log(elapsedtime);
        if (ammo > 0 && elapsedtime > 0.02f && Physics.Raycast(transform.position, forward, out hit) && hit.collider.tag == Tags.Player)
        {
            elapsedtime = 0f;
            transform.LookAt(player.transform.position);
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed*2));
            AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip,transform.position);
            ammo = ammo - 1f;
            insight = true;
        }
        else if(insight && ammo > 0 && elapsedtime > 0.02f)
        {
            transform.LookAt(player.transform.position);
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed * 2));
            AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);
            ammo = ammo - 1f;
        }
        else if(ammo == 0 && elapsedtime > 2.5)
        {
            elapsedtime = 0f;
            ammo = 10;
            magasine -= 1;
        }
        else if(!Physics.Raycast(transform.position, forward, out hit) && hit.collider.tag == Tags.Player)
        {
            insight = false;
        }
    }
}

