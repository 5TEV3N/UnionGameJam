using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Audio
{
    public List<AudioSource> gameAudioList = new List<AudioSource>();
    public float audioVolume = 0.5f;
    public float audioFadeValue = 0;

    public void GetAudio(AudioSource audio)
    {
        // put audio into list
    }

    public void PlayAudio()
    {
        // audio.Play();
    }

    public void FadeAudio()
    {
        // Mathf.Lerp (audio, audioFadeValue, time.deltaTime);
    }

    public void StopAudio()
    {
        //  audio.Stop();
    }

    public void MuteAudio()
    {
        //  audio.Mute = true;
    }
}
