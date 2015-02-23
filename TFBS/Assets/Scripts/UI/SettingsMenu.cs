using UnityEngine.UI;

public class SettingsMenu : Navigation
{
    public void Awake()
    {
        if (SharedState.MusicSource != null)
        {
            Slider slider = FindObjectOfType<Slider>();
            slider.value = SharedState.MusicSource.volume;
        }
    }

    public void AdjustMusic(float volume)
    {
        if (SharedState.MusicSource != null)
            SharedState.MusicSource.volume = volume;
    }
}
