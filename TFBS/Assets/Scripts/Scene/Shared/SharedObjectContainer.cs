using UnityEngine;

public interface ISharedObjectManager
{
    /// <summary>
    /// Called when a new scene is loaded.
    /// </summary>
    /// <param name="newScene">The new scene's shared state.</param>
    void OnSceneChange(GameObject newScene);
}

public class SharedObjectContainer<T, TManager> where T : Object where TManager : ISharedObjectManager, new()
{
    public T SharedObject;
    public readonly TManager Manager;

    public SharedObjectContainer(T sharedObject)
    {
        SharedObject = sharedObject;
        Manager = new TManager();
    }
}
