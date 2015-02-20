using UnityEngine;
using System.Collections;

public class AudioVolume : MonoBehaviour
{
    //variables
    private static AudioVolume instance = null;

    //get
    public static AudioVolume Instance
    {
        get { return instance; }
    }

    //function
    void Awake()
    {
        if (Application.loadedLevel == 0 || Application.loadedLevel == 1)
        {
            if (instance != null && instance != this)
            {
                audio.Stop();
                if (instance.audio.clip != audio.clip)
                {
                    instance.audio.clip = audio.clip;
                    audio.volume = instance.audio.volume;
                    instance.audio.Play();
                }
                Destroy(this.gameObject);
                return;
            }
            else
            {
                instance = this;
                audio.Play();
                DontDestroyOnLoad(this.gameObject);
            }
        }
        else
        {
            audio.Stop();
            instance.audio.Stop();
            Destroy(instance.gameObject);
            Destroy(this.gameObject);
        }
    }

}
