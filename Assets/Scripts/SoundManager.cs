using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    
    public AudioSource track1Source;
    public AudioSource track2Source;
    public AudioSource taptickSource;

    public GameObject BPMslider;

    public void PlayTrackOne(AudioClip clip, float volume)
    {

        track1Source.clip = clip;
        track1Source.volume = volume;
        track1Source.Play();

    }

    public void PlayTrackTwo(AudioClip clip, float volume)
    {
        track2Source.clip = clip;
        track2Source.volume = volume;
        track2Source.Play();
    }

    public void TempoSound(AudioClip clip, float volume)
    {

        taptickSource.clip = clip;
        taptickSource.volume = volume;
        taptickSource.Play();
    }
}