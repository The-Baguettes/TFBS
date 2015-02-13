using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour 
{
    /// <summary>
    /// Made jump and GroundedState function(I tried but I can't finish it now)
    /// </summary>

    public float playerSpeed = 5.0f;
    public float jumpForce = 2.0f;
    private bool hasJumped = false;
    public float cooldownJump = 0.0f;
    public bool grounded = true;
    public float gravity = 2.0f;

    void Start()
    {
        transform.position = new Vector3(0, 1, 0);
    }
    void Update()
    {
        grounderstate();
        jump();
    }
    void jump() // TO DO
    {
        if (Input.GetKey(KeyCode.Space) && hasJumped == false)
        {
            hasJumped = true;
            cooldownJump = 0.0f;
            transform.position = new Vector3(transform.position.x, transform.position.y + jumpForce, transform.position.z);
        }
        cooldownJump =+ cooldownJump* Time.deltaTime ;
        if (hasJumped == true && cooldownJump >= 1)
        {
            hasJumped = false;
        }
    }
    void grounderstate() // TO DO
    {
        if (transform.position.y >= 1)
        {
            grounded = false;
        }
        if (transform.position.y == 1)
        {
            grounded = true;
        }
        while (grounded == true)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y - gravity*Time.deltaTime ,transform.position.z);
        }
    }
   

}
