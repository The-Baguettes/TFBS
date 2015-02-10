using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    public float playerSpeed = 5.0f;

    void Start()
    {
        transform.position = new Vector3(0, 1, 0);
    }

    void Update()
    {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime);
    }
}
