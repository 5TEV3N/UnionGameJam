using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Audio
{
    public List<AudioSource> gameAudioList = new List<AudioSource>();
    public AudioSource gameAudio;
    public float audioVolume = 0.5f;
    public float audioFadeValue = 0;

    public void GetAudio(AudioSource p_audio)
    {
        gameAudio = p_audio;
        gameAudioList.Add(gameAudio);
    }

    public void PlayAudio()
    {
        // gameAudioList.Play();
    }

    public void FadeAudio()
    {
        // Mathf.Lerp (gameAudioList, audioFadeValue, time.deltaTime);
    }

    public void StopAudio()
    {
        //  gameAudioList.Stop();
    }

    public void MuteAudio()
    {
        //  gameAudioList.Mute = true;
    }
}
