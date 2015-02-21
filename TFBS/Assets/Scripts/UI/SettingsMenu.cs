using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public void Awake()
    {
        if (SharedState.MusicSource != null)
        {
            Slider slider = FindObjectOfType<Slider>();
            slider.value = SharedState.MusicSource.volume;
        }
    }

    public void Back()
    {
        Scene.MainMenu.Activate();
    }

    public void Controls()
    {
        // TODO
    }

    public void Music(float volume)
    {
        SharedState.MusicSource.volume = volume;
    }
}
