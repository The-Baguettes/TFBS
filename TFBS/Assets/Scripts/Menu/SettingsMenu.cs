using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : Navigation
{
    Slider music;
    Slider quality;

    protected override void Awake()
    {
        base.Awake();

        music = transform.FindChild("Music").GetComponentInChildren<Slider>();
        quality = transform.FindChild("Quality").GetComponentInChildren<Slider>();
    }

    protected override void Show()
    {
        base.Show();

        quality.value = QualitySettings.GetQualityLevel();

        if (SharedState.MusicSource != null)
            music.value = SharedState.MusicSource.volume;
        else
            music.interactable = false;
    }

    public void AdjustMusic()
    {
        if (SharedState.MusicSource != null)
            SharedState.MusicSource.volume = music.value;
    }

    public void AdjustQuality()
    {
        QualitySettings.SetQualityLevel((int)quality.value);
    }
}
