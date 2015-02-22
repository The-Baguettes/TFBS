using System.Collections.Generic;
using UnityEngine;

public static class SceneManager
{
    static Stack<Scene> sceneHistory = new Stack<Scene>();

    public static void LoadScene(Scene scene)
    {
        sceneHistory.Push((Scene)Application.loadedLevel);
        Application.LoadLevel((int)scene);
    }
    
    public static void LoadPreviousScene()
    {
        Application.LoadLevel((int)sceneHistory.Pop());
    }
}
