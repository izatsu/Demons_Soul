using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] Sound[] musicSounds, sfxSounds;
    [SerializeField] AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
            
    }

    private void Start()
    {
        PlayMusic("MainTheme");   
    }


    public void PlayMusic(string name)
    {
        musicSource.Stop();
        Sound s = Array.Find(musicSounds, x => x.name == name);
        
        if (s == null)
        {
            Debug.Log("Sound not Found");
        }    
        
        else
        {
         
            musicSource.clip = s.clip;
            musicSource.Play();
        }        
    }    

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound not Found");
        }

        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }    

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;

    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;

    }

    public float MusicVolume()
    {
        return musicSource.volume;
    }

    public float SFXVolume()
    {
        return sfxSource.volume;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

}
