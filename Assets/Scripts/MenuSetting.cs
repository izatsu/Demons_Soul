using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSetting : MonoBehaviour
{
    [SerializeField] Button setting_button;
    [SerializeField] Button Resume_button;
    [SerializeField] Button MainMenu_button;

    [SerializeField] GameObject mainSetting;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        setting_button.onClick.AddListener(gm.PauseGame);
        Resume_button.onClick.AddListener(gm.ResumeGame);
        MainMenu_button.onClick.AddListener(gm.BackMenuGame);
        mainSetting.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
