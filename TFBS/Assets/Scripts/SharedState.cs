using UnityEngine;

public class SharedState : MonoBehaviour
{
    /// <summary>
    /// The single shared state instance.
    /// </summary>
    /// <value>The instance.</value>
    public static SharedState Instance { get; private set; }

    /// <summary>
    /// The game's music audio source.
    /// </summary>
    public static AudioSource MusicSource { get; private set; }

    public void Awake()
    {
        // Make sure there is only one SharedState
        if (Instance != null)
        {
            Setup();
            GameObject.Destroy(gameObject);
            return;
        }

        Instance = this;
        Setup();
    }

    /// <summary>
    /// Setup the shared state for the new scene.
    /// </summary>
    void Setup()
    {
        // Make sure we keep the same shared state across scenes
        GameObject.DontDestroyOnLoad(Instance.gameObject);

        SetupMusicSource();
    }

    /// <summary>
    /// Setup the new scene's music source.
    /// </summary>
    void SetupMusicSource()
    {
        // Stop when there is no audio or audio clip or it is disabled
        if (audio == null || audio.clip == null || !audio.enabled)
            return;

        // Stop when the audio clip is the same as in the previous scene
        if (MusicSource != null && audio.clip.Equals(MusicSource.clip))
            return;

        GameObject.DestroyObject(MusicSource);
        MusicSource = audio;
    }
}
