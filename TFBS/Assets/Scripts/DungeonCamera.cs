using UnityEngine;

public class DungeonCamera : MonoBehaviour
{
  /*  public GameObject target;
    Player player; */
    public GameObject target;
    public float rotateSpeed = 5;
    Vector3 offset;

    void Start()
    {
      /*  player = GameObject.FindObjectOfType<Player>();
        transform.position = player.transform.position; */
        offset = target.transform.position - transform.position;
    }

    void LateUpdate()
    {
  /*      transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z + 2);
        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.rotation = rotation; */

        float horizontal = Input.GetAxis("Horizontal") * rotateSpeed;
        target.transform.Rotate(0, horizontal, 0);
        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * offset);
        transform.LookAt(target.transform);
    }
}
