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

    [Header("SummonBoss")]
    [SerializeField] GameObject SummonBoss_prefabs;
    [SerializeField] Transform pos_summon;
    GameObject Summon;
    private bool hasBoss = false;

    [Header("Boss")]
    [SerializeField] GameObject boss_prefabs;
    //[SerializeField] Transform pos_boss;
    GameObject Boss;

    private void Awake()
    {
        player = Instantiate(Player_prefabs, pos_player.position, Quaternion.Euler(0, 0, 0));

    }

    private void Start()
    {
        healthbar = Instantiate(CanvasHealthBar_Prefabs);
        joystickbutton = Instantiate(CanvasJOystick_Prefabs);
        Summon = Instantiate(SummonBoss_prefabs, pos_summon.position, Quaternion.Euler(0, 0, 0));
    }

    private void Update()
    {
        if (Summon == null && !hasBoss)
        {
            hasBoss = true;
            Boss = Instantiate(boss_prefabs, pos_summon.position, Quaternion.Euler(0, 0, 0));
        }
    }

}
