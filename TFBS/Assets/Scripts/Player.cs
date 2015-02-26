using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float sprintSpeed = 15.0f;
    public float movementSpeed = 10.0f;
    public float sneakSpeed = 5.0f;
    public float turningSpeed = 200.0f;
    public float vertical;
    public float PlayerHealth = 100.0f;
    public bool Sneak;
    public bool Sprint;

    void Update()
    {
        Move();
        OnTriggerEnter(collider);
        Death();
    }
    void Move()
    {
        Sneak = Input.GetButton("Sneak");
        Sprint = Input.GetButton("Sprint");
        float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        Debug.Log(horizontal);
        transform.Rotate(0, horizontal, 0);
        if (Sneak)
        {
            vertical = Input.GetAxis("Vertical") * sneakSpeed * Time.deltaTime;
            transform.Translate(0, 0, vertical);
        }
        else if (Sprint)
        {
            vertical = Input.GetAxis("Vertical") * sprintSpeed * Time.deltaTime;
            transform.Translate(0, 0, vertical);
        }
        else
        {
            float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
            transform.Translate(0, 0, vertical);
        }
    }
    void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.tag == "AI")
        {
            PlayerHealth -= 1;
        }
    }
    void Death()
    {
        if (PlayerHealth == 0)
        {
            GameObject.Destroy(this); 
        }
    }
}
