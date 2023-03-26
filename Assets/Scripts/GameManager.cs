using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        player = Instantiate(Player_prefabs, pos_player.position, Quaternion.Euler(0, 0, 0));

    }

    private void Start()
    {
        healthbar = Instantiate(CanvasHealthBar_Prefabs);
    }

}
