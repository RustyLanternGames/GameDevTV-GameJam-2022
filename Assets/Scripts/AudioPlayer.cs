using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{ 
    AudioSource audioSource;
    [SerializeField] AudioClip overWorldMusic;
    [SerializeField] AudioClip buildingMusic;
    [SerializeField] AudioClip characterMusic;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOverworldMusic()
    {
        audioSource.Stop();
        audioSource.clip = overWorldMusic;
        audioSource.Play();
    }

    public void PlayBuildingMusic()
    {
        audioSource.Stop();
        audioSource.clip = buildingMusic;
        audioSource.Play();
    }

    public void PlayCharacterMusic()
    {
        audioSource.Stop();
        audioSource.clip = characterMusic;
        audioSource.Play();
    }
}
