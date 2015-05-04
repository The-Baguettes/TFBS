using UnityEngine.UI;
using UnityEngine;

public class SettingsMenu : Navigation
{
    Slider quality;

    public void Awake()
    {
        if (SharedState.MusicSource != null)
        {
            Slider slider = FindObjectOfType<Slider>();
            slider.value = SharedState.MusicSource.volume;
        }
        quality = GameObject.Find("SliderQ").GetComponent<Slider>();
    }

    public void AdjustMusic(float volume)
    {
        if (SharedState.MusicSource != null)
            SharedState.MusicSource.volume = volume;
    }

    public void Quality()
    {
        QualitySettings.SetQualityLevel((int)quality.value);
    }
}
