using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    public void Setting()
    {
        AudioManager.Instance.PlaySFX("ButtonBack");
        SceneManager.LoadScene("Setting");
    }    

    public void Quit()
    {
        Application.Quit();
    }

    public void BackMenu()
    {
        AudioManager.Instance.PlaySFX("ButtonBack");
        SceneManager.LoadScene("MainMenu");
    }   
    
    public void About()
    {
        SceneManager.LoadScene("Credits");
    }    
}
