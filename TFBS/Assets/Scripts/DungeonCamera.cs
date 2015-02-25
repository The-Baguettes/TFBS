using UnityEngine;

public class DungeonCamera : MonoBehaviour
{
    public GameObject target;
    Player player;

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3, player.transform.position.z - 7);
    }

    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3, player.transform.position.z - 7);
        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.rotation = rotation;
    }
}
