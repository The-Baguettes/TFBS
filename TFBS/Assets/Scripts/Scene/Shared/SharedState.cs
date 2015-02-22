using UnityEngine;

public class SharedState : Singleton<SharedState>, ISingleton
{
    /// <summary>
    /// The game's music audio source.
    /// </summary>
    public static AudioSource MusicSource
    {
        get { return MusicSourceContainer != null
            ? MusicSourceContainer.SharedObject : null; }
        set { MusicSourceContainer.SharedObject = value; }
    }

    static SharedObjectContainer<AudioSource, MusicManager> MusicSourceContainer;

    // Called only once by Singleton
    public void Init()
    {
        MusicSourceContainer = new SharedObjectContainer<AudioSource, MusicManager>(Instance.audio);
    }

    public void OnLevelWasLoaded(int _)
    {
        if (this != Instance)
            MusicSourceContainer.Manager.OnSceneChange(gameObject);
    }
}
