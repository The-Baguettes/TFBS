using UnityEditor;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(MetaScene.FirstLevel);
    }

    public void Settings()
    {
        SceneManager.LoadScene(Scene.SettingsMenu);
    }

    public void Quit()
    {
        if (Application.isEditor)
            EditorApplication.isPlaying = false;
        else
            Application.Quit();
    }
}
