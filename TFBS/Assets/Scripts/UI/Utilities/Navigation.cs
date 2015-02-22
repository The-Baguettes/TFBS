using UnityEditor;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    #region Meta
    public void Back()
    {
        SceneManager.LoadPreviousScene();
    }
    
    public void Quit()
    {
        if (Application.isEditor)
            EditorApplication.isPlaying = false;
        else
            Application.Quit();
    }
    #endregion

    #region Menus
    public void MainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu);
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene(Scene.SettingsMenu);
    }

    public void SettingsControlsMenu()
    {
        // TODO
    }
    #endregion
}
