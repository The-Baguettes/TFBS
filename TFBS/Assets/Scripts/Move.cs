using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public float jumpForce = 0.01f;

    void Start()
    {
        transform.position = new Vector3(0, 1, 0);
    }

    void LateUpdate()
    {
        while (transform.position.y <= 0)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }  
    }

    void Update()
    {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + jumpForce, transform.position.z);
        }
        
    }
}
