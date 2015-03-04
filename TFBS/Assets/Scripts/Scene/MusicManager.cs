using UnityEngine;

public class MusicManager : ISharedObjectManager
{
    public MusicManager()
    { }

    public void OnSceneChange(GameObject newScene)
    {
        AudioSource audio;

        // Stop when there is no audio or audio clip or it is disabled
        if ((audio = newScene.GetComponent<AudioSource>()) ?? audio.clip == null || !audio.enabled)
            return;

        // Stop when the audio clip is the same as in the previous scene
        if (SharedState.MusicSource != null && audio.clip.Equals(SharedState.MusicSource.clip))
            return;

        GameObject.DestroyObject(SharedState.MusicSource);
        SharedState.MusicSource = audio;
    }
}
