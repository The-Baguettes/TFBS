using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FullscreenOrNot : MonoBehaviour
{
    Text text;
    public int width;
    public int height;

    void Start()
    {
        text = GetComponent<Text>();
        width = Screen.width;
        height = Screen.height;
    }
    void Update()
    {
        width = Screen.width;
        height = Screen.height;
    }
    public void Fullscreen()
    {
        if (!Screen.fullScreen)
        {
            Screen.SetResolution(width, height, true);
            text.text = "Fullscreen";
        }
        else
        {
            Screen.SetResolution(width, height, false);
            text.text = "Windowed";
        }
    }

}
