using UnityEngine;

public class MusicManager : ISharedObjectManager
{
    public MusicManager()
    { }

    public void OnSceneChange(GameObject newScene)
    {
        // Stop when there is no audio or audio clip or it is disabled
        if (newScene.audio ?? newScene.audio.clip == null || !newScene.audio.enabled)
            return;

        // Stop when the audio clip is the same as in the previous scene
        if (SharedState.MusicSource != null && newScene.audio.clip.Equals(SharedState.MusicSource.clip))
            return;

        GameObject.DestroyObject(SharedState.MusicSource);
        SharedState.MusicSource = newScene.audio;
    }
}
