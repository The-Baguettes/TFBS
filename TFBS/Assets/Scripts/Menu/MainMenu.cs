using UnityEngine;

public class MainMenu : Navigation
{
    protected override void Start()
    {
        base.Start();

        if (SceneManager.LoadedScene == Scene.MainMenu)
            Show();
    }

    public void Play()
    {
        NetworkManager.IsMultiPlayer = false;
        SceneManager.LoadScene(MetaScene.FirstLevel);
    }

    public void MultiPlayer()
    {
        NetworkManager.IsMultiPlayer = true;
        SceneManager.LoadScene(Scene.Floor1);
    }
}
