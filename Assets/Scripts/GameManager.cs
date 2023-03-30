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
    GameObject Summon;
    private bool hasBoss = false;

    [Header("Boss")]
    [SerializeField] GameObject boss_prefabs;
    Vector3 pos_boss;
    GameObject Boss;

    [Header("UI health Boss")]
    [SerializeField] GameObject CanvasHealthBarBoss_Prefabs;
    GameObject healthbarBoss;

    [Header("ButtonReset")]
    [SerializeField] GameObject buttonReset;

    string nameScene;

    private void Awake()
    {
        player = Instantiate(Player_prefabs, pos_player.position, Quaternion.Euler(0, 0, 0));

    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;

        Debug.Log("Chay start gamemanager");
        nameScene = SceneManager.GetActiveScene().name;

        healthbar = Instantiate(CanvasHealthBar_Prefabs);
        joystickbutton = Instantiate(CanvasJOystick_Prefabs);
        /*if (nameScene == "RoomBoss1")
            Summon = Instantiate(SummonBoss_prefabs, pos_summon.position, Quaternion.Euler(0, 0, 0));*/
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(SceneManager.GetActiveScene().name == "RoomBoss1")
        {
            nameScene = SceneManager.GetActiveScene().name;
            player.transform.position = Vector2.zero;
            player.layer = LayerMask.NameToLayer("Layer 1");
            player.GetComponent<SpriteRenderer>().sortingLayerName = "Layer 1";
            Summon = Instantiate(SummonBoss_prefabs,new Vector3(0,20,0), Quaternion.Euler(0, 0, 0));
            pos_boss = Summon.transform.position;
        }
           
    }



    private void Update()
    {
        
        if(nameScene == "RoomBoss1")
        {
            if (Summon == null && !hasBoss)
            {
                hasBoss = true;
                Boss = Instantiate(boss_prefabs, pos_boss, Quaternion.Euler(0, 0, 0));
                healthbarBoss = Instantiate(CanvasHealthBarBoss_Prefabs);
            }
        }    
        

        /*if (player.GetComponent<PlayerHealth>().isDie)
        {
            Time.timeScale = 0;
            buttonReset.SetActive(true);
            player.GetComponent<PlayerHealth>().isDie = false;
            Destroy(player);
        }*/

    }

    

    public void Reset()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("RoomBoss1");
    }
}
