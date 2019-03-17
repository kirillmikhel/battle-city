using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip clipIdle;
    public AudioClip clipMoving;
    public AudioClip clipShoot;
    public AudioClip clipHitSteel;

    public AudioSource audioIdle;
    public AudioSource audioMoving;
    public AudioSource audioShoot;
    public AudioSource audioHitSteel;

    public void Awake()
    {
        audioIdle = AddAudioSource(clipIdle, true, true, 0.5f);
        audioMoving = AddAudioSource(clipMoving, true, true, 0.5f);
        audioShoot = AddAudioSource(clipShoot, false, false, 1f);
        audioHitSteel = AddAudioSource(clipHitSteel, false, false, 1f);
    }

    private AudioSource AddAudioSource(AudioClip clip, bool loop, bool playAwake, float volume)
    {
        var newAudioSource = gameObject.AddComponent<AudioSource>();

        newAudioSource.clip = clip;
        newAudioSource.loop = loop;
        newAudioSource.playOnAwake = playAwake;
        newAudioSource.volume = volume;

        return newAudioSource;
    }
}