using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float sneakSpeed = 5.0f;
    public float turningSpeed = 60f;
    public bool canJump;

    void Update()
    {
        canJump = transform.position.y <= 1;

        float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        Debug.Log(horizontal);
        transform.Rotate(0, horizontal, 0);

        float playerSpeed = Input.GetKeyDown(KeyCode.LeftShift) ? sneakSpeed : movementSpeed;

        float vertical = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);

        if (canJump && Input.GetKeyDown(KeyCode.Space))
            transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
    }
}
