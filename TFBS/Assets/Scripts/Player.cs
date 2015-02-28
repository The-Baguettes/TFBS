using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float sprintSpeed = 15f;
    public float movementSpeed = 10f;
    public float sneakSpeed = 5f;
    public float turningSpeed = 200f;
    public float PlayerHealth = 100f;

    void Update()
    {
        Move();
        Death();
    }

    void Move()
    {
        bool Sneak = Input.GetButton("Sneak");
        bool Sprint = Input.GetButton("Sprint");

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Rotate(0, horizontal * turningSpeed * Time.deltaTime, 0);
        
        if (Sneak)
            transform.Translate(0, 0, vertical * sneakSpeed * Time.deltaTime);
        else if (Sprint)
            transform.Translate(0, 0, vertical * sprintSpeed * Time.deltaTime);
        else
            transform.Translate(0, 0, vertical * movementSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
            PlayerHealth -= 50f;
    }

    void Death()
    {
        return;
        if (PlayerHealth <= 0)
        {
            // OverlayMenu GameOver = new OverlayMenu();
            // GameOver.GameOver();
            Destroy(this.gameObject);
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
