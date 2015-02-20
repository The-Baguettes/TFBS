using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float sneakSpeed = 5.0f;
    public float turningSpeed = 60.0f;
    public bool grounded;
    void Update()
    {
        if (transform.position.y <= 1)
        {
            grounded = true;
        }
        if (transform.position.y > 1)
        {
            grounded = false;
        }
        float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W))
        {
            float vertical = Input.GetAxis("Vertical") * sneakSpeed * Time.deltaTime;
            transform.Translate(0, 0, vertical);
        }
        else
        {
            float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
            transform.Translate(0, 0, vertical);
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        }


    }
}