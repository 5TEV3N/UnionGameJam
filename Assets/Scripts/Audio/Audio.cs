using UnityEngine;
using System.Collections;

public class Audio
{
    public AudioSource gameAudio;
    public float audioVolume = 0.5f;
    public float audioFadeValue = 0;

    public void GetAudio(AudioSource p_audio)
    {
        gameAudio = p_audio;
        gameAudio.volume = audioVolume;
    }

    public void PlayAudio()
    {
        gameAudio.Play();
    }

    public void FadeOutAudio()
    {
        audioVolume = Mathf.Lerp (audioVolume, audioFadeValue, Time.deltaTime);
    }

    public void FadeInAudio()
    {
        audioVolume = Mathf.Lerp (audioFadeValue, audioVolume, Time.deltaTime);
    }

    public void StopAudio()
    {
        gameAudio.Stop();
    }

    public void MuteAudio()
    {
        gameAudio.mute = true;
    }

    public void UnMuteAudio()
    {
        gameAudio.mute = false;
    }
}
