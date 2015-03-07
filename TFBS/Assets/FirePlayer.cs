using UnityEngine;

public class FirePlayer : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 50;
    public int ammo = 30;
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
        if (ammo > 0 && elapsedtime > 0.2f && Input.GetButtonDown(Inputs.Fire))
        {
            elapsedtime = 0;
            ammo--;
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(0, 0, speed);
            AudioSource.PlayClipAtPoint(fire, transform.position);
        }
        else if (magasine > 0 && Input.GetKeyDown(KeyCode.R))
        {
            ammo = 30;
            magasine--;
            AudioSource.PlayClipAtPoint(reload, transform.position);
        }
    }
}
