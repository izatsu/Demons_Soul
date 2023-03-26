using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] GameObject Player_prefabs;
    [SerializeField] Transform pos_player;
    GameObject player;

    [Header("UI health player")]
    [SerializeField] GameObject CanvasHealthBar_Prefabs;
    GameObject healthbar;

    [Header("UI Joystick and button player")]
    [SerializeField] GameObject CanvasJOystick_Prefabs;
    GameObject joystickbutton;
    Button button_dash;


    private void Awake()
    {
        player = Instantiate(Player_prefabs, pos_player.position, Quaternion.Euler(0, 0, 0));

    }

    private void Start()
    {
        healthbar = Instantiate(CanvasHealthBar_Prefabs);

        joystickbutton = Instantiate(CanvasJOystick_Prefabs);

    }

}
