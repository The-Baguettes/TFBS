public class MainMenu : MenuBase
{
    protected override void Start()
    {
        base.Start();

        if (SceneManager.LoadedScene == Scene.MainMenu)
            Show();
    }
}
