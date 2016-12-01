using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Audio: MonoBehaviour
{
    public List<AudioSource> soundBites = new List<AudioSource>();
    public AudioSource bgm;
    public float bgmFadeInValue = 0.5f;
    public float bgmFadeOutValue = 0f;
    public bool startBGM = true;

    void Update()
    {
        if (startBGM == true)
        {
            FadeInBGM();
        }
        else
        {
            FadeOutBGM();
        }
    }

    public void PlayAudio()
    {
        //Play any soundBites here
    }

    public void FadeOutBGM()
    {
        bgm.volume = Mathf.Lerp (bgm.volume, bgmFadeOutValue, Time.deltaTime);
    }

    public void FadeInBGM()
    {
        bgm.volume = Mathf.Lerp (bgm.volume, bgmFadeInValue, Time.deltaTime);
    }

    public void StopAudio()
    {
        bgm.Stop();
    }

    public void MuteAudio()
    {
        bgm.mute = true;
    }

    public void UnMuteAudio()
    {
        bgm.mute = false;
    }
}
