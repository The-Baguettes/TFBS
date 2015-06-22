using UnityEngine;
using System.Collections;

public class MovingText : MonoBehaviour
{

    public Transform text;
    public float speed;
    float position;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
        if (text.position.y > -410)
        {
            text.position = new Vector3(text.position.x, text.position.y - speed, text.position.z);
        }
    }
}
