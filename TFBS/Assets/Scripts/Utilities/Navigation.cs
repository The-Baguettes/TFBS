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
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
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
    #endregion

    public void Play()
    {
        SceneManager.LoadScene(MetaScene.FirstLevel);
        Time.timeScale = 1;
    }
}
