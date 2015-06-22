﻿using UnityEngine;

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
        SceneManager.LoadScene(MetaScene.FirstLevel);
    }

    public void MultiPlayer()
    {
        NetworkManager.IsMultiPlayer = true;
        SceneManager.LoadScene(Scene.Game);
    }
}
