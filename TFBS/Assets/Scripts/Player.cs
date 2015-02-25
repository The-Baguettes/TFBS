using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float sneakSpeed = 5.0f;
    public float turningSpeed = 200.0f;
    public float vertical;
    public bool Sneak;

    void Update()
    {
        Sneak = Input.GetButton("Sneak");
        float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        Debug.Log(horizontal);
        transform.Rotate(0, horizontal, 0);
        if (Sneak)
        {
            vertical = Input.GetAxis("Vertical") * sneakSpeed * Time.deltaTime;
            transform.Translate(0, 0, vertical);
        }
        else
        {
            float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
            transform.Translate(0, 0, vertical);
        }
    }
}
