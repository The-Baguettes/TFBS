using UnityEditor;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        Scene.GameBeginning.Activate();
    }

    public void Settings()
    {
        Scene.SettingsMenu.Activate();
    }

    public void Quit()
    {
        if (Application.isEditor)
            EditorApplication.isPlaying = false;
        else
            Application.Quit();
    }
}
