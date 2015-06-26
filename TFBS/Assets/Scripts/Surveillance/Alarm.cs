using System.Collections;
using UnityEngine;

public class Alarm : BaseComponent
{
    const float totalDuration = 5;
    const float lightCycleDuration = .5f;

    const int animateTimes = (int)(totalDuration / lightCycleDuration);

    new AudioSource audio;
    Light spotlight;

    float loopDelay;
    float intensityDelta;
    float maxIntensity;
    int soundTimes;

    protected void Awake()
    {
        audio = GetComponent<AudioSource>();

        if (audio != null)
            audio.loop = true;

        spotlight = GetComponent<Light>();
        spotlight.enabled = false;
        maxIntensity = spotlight.intensity;
        spotlight.intensity = 0;

        intensityDelta = lightCycleDuration / maxIntensity;
        loopDelay = .05f; // FIXME: Correct formula
    }

    #region Event Management
    protected override void HookUpEvents()
    {
        SurveillanceCam.PlayerSpotted += SurveillanceCam_PlayerSpotted;
    }

    protected override void UnHookEvents()
    {
        SurveillanceCam.PlayerSpotted -= SurveillanceCam_PlayerSpotted;
    }
    #endregion

    #region Event Handling
    void SurveillanceCam_PlayerSpotted(Vector3 spottedAt)
    {
        if (soundTimes++ == 0) // There is no coroutine running
            StartCoroutine(soundAlarm());
    }
    #endregion

    IEnumerator soundAlarm()
    {
        if (audio != null && audio.clip != null)
            audio.Play();
    
        spotlight.enabled = true;

        do {
            for (int i = 0; i < animateTimes; i++)
            {
                while (spotlight.intensity < maxIntensity)
                {
                    spotlight.intensity += intensityDelta;
                    yield return new WaitForSeconds(loopDelay);
                }

                while (spotlight.intensity > 0)
                {
                    spotlight.intensity -= intensityDelta;
                    yield return new WaitForSeconds(loopDelay);
                }
            }

            // Decrement at the end to allow reusing coroutine
        } while (--soundTimes > 0);

        spotlight.enabled = false;

        if (audio != null && audio.clip != null)
        {
            yield return new WaitForSeconds(audio.clip.length - audio.time);

            if (soundTimes == 0)
                audio.Stop();
        }
    }
}
