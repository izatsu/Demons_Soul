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

    [Header("SummonBoss")]
    [SerializeField] GameObject SummonBoss_prefabs;
    GameObject Summon;
    private bool hasBoss1 = false;

    [Header("DoorBoss1")]
    [SerializeField] GameObject Door1_prefab;
    GameObject door1;


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
    Vector3 pos_boss2;
    GameObject Dökkálfar;

    [Header("UI health Boss 2")]
    [SerializeField] GameObject CanvasHealthBarBoss2_Prefabs;
    GameObject healthbarBoss2;

    [Header("SummonBoss2")]
    [SerializeField] GameObject SummonBoss2_prefabs;
    GameObject Summon2;
    private bool hasBoss2 = false;

    [Header("DoorBoss2")]
    [SerializeField] GameObject Door2_prefab;
    GameObject door2;


    [Header("UI Setting")]
    [SerializeField] GameObject Canvassetting_Prefab;
    [SerializeField] GameObject CavasMenusetting_Prefab;
    GameObject Setting;
    GameObject MenuSetting;

    [Header("Guide")]
    [SerializeField] GameObject Canvasguide_Prefab;

    [Header("TimeLineBoss2")]
    [SerializeField] GameObject CanvasTimeLineBoss2_Prefab;


    string nameScene;

    Vector3 posPl;

    [SerializeField] static GameManager instance;

    bool checkUse1 = false;
    bool checkUse2 = false;

    AudioManager _audio;


    //fps
    public int frameRate = 60;


    private void Awake()
    {
        Application.targetFrameRate = frameRate;

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
        _audio = FindObjectOfType<AudioManager>();
        _audio.PlayMusic("WorldMapTheme");
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

        DontDestroyOnLoad(Canvassetting_Prefab);

        if (Setting == null)
        {
            Setting = Instantiate(Canvassetting_Prefab);
            MenuSetting = GameObject.Find("BackGroudSetting");
            DontDestroyOnLoad(Setting);
            
        }
        else
        {
            Destroy(Setting);
        }

        Instantiate(Canvasguide_Prefab);

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

        if (SceneManager.GetActiveScene().name == "RoomBoss2")
        {
            Debug.Log("Chay ham khi doi scene ");
            nameScene = SceneManager.GetActiveScene().name;
            player.transform.position = new Vector2(-1.56f, -1.83f);
            player.layer = LayerMask.NameToLayer("Layer 1");
            player.GetComponent<SpriteRenderer>().sortingLayerName = "Layer 1";
            Summon2 = Instantiate(SummonBoss2_prefabs, new Vector3(-1.69f, 26.05f, 0), Quaternion.Euler(0, 0, 0));
            pos_boss2 = Summon2.transform.position;
        }

        if (SceneManager.GetActiveScene().name == "WorldMap" && winboss1 && !checkUse1)
        {
            checkUse1 = true;
            Debug.Log("Chay ham khi doi scene ");
            nameScene = SceneManager.GetActiveScene().name;
            player.transform.position = new Vector3(25.87f, 67.51f, 0f);
            player.layer = LayerMask.NameToLayer("Layer 2");
            player.GetComponent<SpriteRenderer>().sortingLayerName = "Layer 2";         
        }

        if (SceneManager.GetActiveScene().name == "WorldMap" && winboss2 && !checkUse2)
        {
            checkUse2 = true;
            Debug.Log("Chay ham khi doi scene ");
            nameScene = SceneManager.GetActiveScene().name;
            player.transform.position = new Vector3(-19.24f, 57.83f, 0f);
            player.layer = LayerMask.NameToLayer("Layer 2");
            player.GetComponent<SpriteRenderer>().sortingLayerName = "Layer 2";
        }

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            _audio.PlayMusic("MainTheme");
            player.transform.position = new Vector2(-4.52f, -8.89f);
            player.layer = LayerMask.NameToLayer("Layer 1");
            player.GetComponent<SpriteRenderer>().sortingLayerName = "Layer 1";

            OffUIGame();
            Setting.SetActive(false);
            MenuSetting.SetActive(false);

        }    

        if(SceneManager.GetActiveScene().name == "WorldMap")
        {
            OnUIGame();
            _audio.PlayMusic("WorldMapTheme");
            Setting.SetActive(true);
        }


        /*if (SceneManager.GetActiveScene().name == "TestTimeLine")
        {
            OffUIGame();
            _audio.PlayMusic("WorldMapTheme");
            Setting.SetActive(false);

            Invoke("LoadSceneWorldMap", 7f);
        }*/

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

                _audio.PlayMusic("ThemeRoomBoss1");
                door1 = Instantiate(Door1_prefab,new Vector3(-1.9f, 10.7f,0f) , Quaternion.Euler(0, 0, 0));
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

        if (SceneManager.GetActiveScene().name == "RoomBoss2")
        {
            Debug.Log("Dang o scene boss 2");
            Debug.Log("hasBoss: " + hasBoss2);
            if (Summon2 != null)
                hasBoss2 = false;
            if (Summon2 == null && !hasBoss2 && !winboss2)
            {
                Debug.Log("Tao boss");
                hasBoss2 = true;

                _audio.PlayMusic("ThemeRoomBoss2");

                door2 = Instantiate(Door2_prefab, new Vector3(-2f, 11f, 0f), Quaternion.Euler(0, 0, 0));
                Dökkálfar = Instantiate(Dökkálfar_prefabs, pos_boss2, Quaternion.Euler(0, 0, 0));
                healthbarBoss2 = Instantiate(CanvasHealthBarBoss2_Prefabs);
            }

            if (Dökkálfar == null && hasBoss2)
            {
                Destroy(healthbarBoss2);
                winboss2 = true;
                hasBoss2 = false;

                _audio.PlayMusic("WorldMapTheme");
                GameObject Timeline = Instantiate(CanvasTimeLineBoss2_Prefab);
                Destroy(Timeline, 23f);

               /* SceneManager.LoadScene("TestTimeLine");*/


                Tele = Instantiate(Tele_Prefab, pos_boss2, Quaternion.Euler(0, 0, 0));
                Tele.GetComponent<Cainos.PixelArtTopDown_Basic.PropsAltar>().number = 4;
                Tele.GetComponent<Cainos.PixelArtTopDown_Basic.PropsAltar>().loadScene = 1;

            }           
        }

        if (player == null)
        {
            SceneManager.LoadScene("WorldMap");
            SpawnPlayer();
        }      
          
    }


    private void OnUIGame()
    {
        player.SetActive(true);
        healthbar.SetActive(true);
        joystickbutton.SetActive(true);
    }    

    private void OffUIGame()
    {
        player.SetActive(false);
        healthbar.SetActive(false);
        joystickbutton.SetActive(false);
    }    

    private void LoadSceneWorldMap()
    {
        SceneManager.LoadScene("WorldMap");
    }


    public void PauseGame()
    {

        _audio.PlaySFX("ButtonOption");
        Time.timeScale = 0;
        OffUIGame();
        MenuSetting.SetActive(true);
    }    

    public void ResumeGame()
    {

        _audio.PlaySFX("ButtonBack");
        Time.timeScale = 1;
        OnUIGame();
        MenuSetting.SetActive(false);
    }    

    public void BackMenuGame()
    {

        _audio.PlaySFX("ButtonBack");
        Time.timeScale = 1;       
        SceneManager.LoadScene("MainMenu");
    }    

   
}
