using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Slider _musicSlider, _SFXslider;


    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        UpdateVolume();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateVolume();
    }

    public void UpdateVolume()
    {
        _musicSlider.value = AudioManager.Instance.MusicVolume();
        _SFXslider.value = AudioManager.Instance.SFXVolume();
    }    

    public void toggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }
    public void toggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }
    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_SFXslider.value);
    }

}
