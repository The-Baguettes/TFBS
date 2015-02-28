using UnityEngine;

public class DungeonCamera : MonoBehaviour
{
    static Vector3 positionOffset = new Vector3(0f, 2.5f, -2.7f);
    static Vector3 lookatOffset = new Vector3(0f, 0f, 3f);

    GameObject target;

    void Start()
    {
        target = GameObject.FindWithTag(Tags.Player);
    }

    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(0, target.transform.eulerAngles.y, 0);
        Vector3 t_pos = target.transform.position;
        
        transform.position = t_pos + rotation * positionOffset;
        transform.LookAt(t_pos + rotation * lookatOffset);
    }
}
