public class MainMenu : MenuBase
{
    protected void Awake()
    {
        if (SceneManager.LoadedScene == Scene.MainMenu)
            Show();
    }
}
