using System.Collections.Generic;
using UnityEngine;

public static class SceneManager
{
    public static Scene LoadedScene = (Scene)Application.loadedLevel;

    static Stack<Scene> sceneHistory = new Stack<Scene>();

    public static void LoadScene(Scene scene)
    {
        LoadedScene = scene;
        sceneHistory.Push((Scene)Application.loadedLevel);
        Application.LoadLevel((int)scene);
    }
    
    public static void LoadPreviousScene()
    {
        LoadedScene = sceneHistory.Pop();
        Application.LoadLevel((int)LoadedScene);
    }
}
