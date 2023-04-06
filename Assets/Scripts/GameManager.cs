using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
    private bool hasBoss1 = false;

    [Header("Boss")]
    [SerializeField] GameObject boss_prefabs;
    Vector3 pos_boss;
    GameObject Boss;

    [Header("UI health Boss")]
    [SerializeField] GameObject CanvasHealthBarBoss_Prefabs;
    GameObject healthbarBoss;


    [Header("WinBoss")]
    [SerializeField] GameObject Tele_Prefab;
    public bool winboss1 = false;
    public bool winboss2 = false;
    GameObject Tele;

    [Header("Dökkálfar")]
    [SerializeField] GameObject Dökkálfar_prefabs;
    //Vector3 pos_boss;
    GameObject Dökkálfar;

    string nameScene;

    Vector3 posPl;

    [SerializeField] static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        

    }

    private void Start()
    {
        Debug.Log("chay start cua gameManager");
        SceneManager.sceneLoaded += OnSceneLoaded;
        nameScene = SceneManager.GetActiveScene().name;
        posPl = Vector3.zero;


        if (player == null)
        {
            player = Instantiate(Player_prefabs, pos_player.position, Quaternion.Euler(0, 0, 0));
            DontDestroyOnLoad(player);
            Debug.Log("Tao Player");
        }
        else
        {
            Destroy(player);
        }

        if (healthbar == null)
        {
            healthbar = Instantiate(CanvasHealthBar_Prefabs);
            DontDestroyOnLoad(healthbar);
        }
        else
        {
            Destroy(healthbar);
        }

        if (joystickbutton == null)
        {
            joystickbutton = Instantiate(CanvasJOystick_Prefabs);
            DontDestroyOnLoad(joystickbutton);
        }
        else
        {
            Destroy(joystickbutton);
        }

        Dökkálfar = Instantiate(Dökkálfar_prefabs, transform.position,quaternion.identity);



    }

    void SpawnPlayer()
    {
        GameObject newPlayer = Instantiate(Player_prefabs, new Vector3(1.44f, 27.88f, 0f), Quaternion.Euler(0, 0, 0));
        player = newPlayer;
        DontDestroyOnLoad(player);
    } 

    public void RespawnPlayer()
    {
        hasBoss1 = false;
        Destroy(player.gameObject);
        SpawnPlayer();
    } 
        
 

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if(SceneManager.GetActiveScene().name == "RoomBoss1")
        {
            Debug.Log("Chay ham khi doi scene ");
            nameScene = SceneManager.GetActiveScene().name;
            player.transform.position = Vector2.zero;
            player.layer = LayerMask.NameToLayer("Layer 1");
            player.GetComponent<SpriteRenderer>().sortingLayerName = "Layer 1";
            Summon = Instantiate(SummonBoss_prefabs,new Vector3(0,20,0), Quaternion.Euler(0, 0, 0));
            pos_boss = Summon.transform.position;
        }

        if (SceneManager.GetActiveScene().name == "WorldMap" && winboss1)
        {
            Debug.Log("Chay ham khi doi scene ");
            nameScene = SceneManager.GetActiveScene().name;
            player.transform.position = new Vector3(25.87f, 67.51f, 0f);
            player.layer = LayerMask.NameToLayer("Layer 2");
            player.GetComponent<SpriteRenderer>().sortingLayerName = "Layer 2";         
        }
    }



    private void Update()
    {
        
        if(SceneManager.GetActiveScene().name == "RoomBoss1")
        {
            Debug.Log("Dang o scene boss");
            Debug.Log("hasBoss: " + hasBoss1);
            if (Summon != null)
                hasBoss1 = false;
            if (Summon == null && !hasBoss1 && !winboss1)
            {
                Debug.Log("Tao boss");
                hasBoss1 = true;
                Boss = Instantiate(boss_prefabs, pos_boss, Quaternion.Euler(0, 0, 0));
                healthbarBoss = Instantiate(CanvasHealthBarBoss_Prefabs);
            }

            if (Boss == null && hasBoss1)
            {
                Destroy(healthbarBoss);
                winboss1 = true;
                hasBoss1 = false;
                Tele = Instantiate(Tele_Prefab, pos_boss, Quaternion.Euler(0, 0, 0));
                Tele.GetComponent<Cainos.PixelArtTopDown_Basic.PropsAltar>().number = 3;
                Tele.GetComponent<Cainos.PixelArtTopDown_Basic.PropsAltar>().loadScene = 1;
                
            }    
               
        }

        
        if(player == null)
        {
            SceneManager.LoadScene("WorldMap");
            SpawnPlayer();
        } 
            
            
    }
}
