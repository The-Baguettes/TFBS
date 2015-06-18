using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Resolution : MonoBehaviour
{
    Text text;
    int width = Screen.width;
    int height = Screen.height;
    bool full;

    void Start()
    {
        full = Screen.fullScreen;
        text = GetComponent<Text>();
        text.text = width + " x " + height;
    }
    void Update()
    {
        full = Screen.fullScreen;
    }
    public void changeRes()
    {
        if (text.text == "1024 x 768")
        {
            Screen.SetResolution(1920, 1080, full);
            text.text = "1920 x 1080";
        }
        else
        {
            Screen.SetResolution(1024, 768, full);
            text.text = "1024 x 768";
        }
    }
}
