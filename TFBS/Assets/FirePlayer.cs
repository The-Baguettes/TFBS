using UnityEngine;
using System.Collections;

public class FirePlayer : MonoBehaviour
{
   
        public Rigidbody projectile;
        public float speed = 20;
        public float ammo = 30;
        public int magasine = 4;
        float elapsedtime = 0f;

        AudioClip fire;
        AudioClip reload;

        void Start()
        {
            fire = transform.FindChild("Fire").GetComponent<AudioSource>().clip;
            reload = transform.FindChild("Reload").GetComponent<AudioSource>().clip;
        }

        void Update()
        {
            elapsedtime += Time.deltaTime;
            if (ammo > 0 && Input.GetButtonDown(Inputs.Fire) && elapsedtime > 0.2f)
            {
                elapsedtime = 0;
                Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
                instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, -speed));
                AudioSource.PlayClipAtPoint(fire, transform.position);
                ammo = ammo - 1f;
            }
            else if (Input.GetKeyDown(KeyCode.R) && elapsedtime >2.5 && magasine != 0)
            {
                ammo = 30;
                magasine -= 1;
                AudioSource.PlayClipAtPoint(reload, transform.position);
            }
        }
    }

