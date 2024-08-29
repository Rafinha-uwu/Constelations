using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    public static AudioManager Instance;

   // Start is called before the first frame update
   void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    // Play from other script Music
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        musicSource.clip = s.clip;
        musicSource.Play();
    }
    // Play from other script Sfx
    public void PlaySfx(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        sfxSource.PlayOneShot(s.clip);
    }

    // Volume

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    // Instance
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
}
