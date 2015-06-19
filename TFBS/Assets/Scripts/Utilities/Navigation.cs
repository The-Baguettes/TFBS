using UnityEngine;

public class Navigation : MenuBase
{
    protected GameOverMenu GameOver;
    protected MainMenu MainMenu;
    //protected SettingsMenu Settings;

    protected override void Awake()
    {
        base.Awake();

        GameOver = GameObject.FindObjectOfType<GameOverMenu>();
        MainMenu = GameObject.FindObjectOfType<MainMenu>();
        //Settings = GameObject.FindObjectOfType<SettingsMenu>();
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ShowGameOver()
    {
        GameOver.Show();
    }

    public void ShowMainMenu()
    {
        MainMenu.Show();
    }

    public void ShowSettings()
    {
        //Settings.Show();
        SceneManager.LoadScene(Scene.SettingsMenu);
    }
}
