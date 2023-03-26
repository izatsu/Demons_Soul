using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Transform pos_attack1;
    [SerializeField] Transform pos_attack2;
    [SerializeField] GameObject bullet_prefabs;
    private float Time_delay = 0.5f;
    private bool canAttack = true;

    PlayerHealth pl_h;

    Button attack_button;

    private void Start()
    {
        pl_h = GetComponent<PlayerHealth>();
        attack_button = GameObject.Find("AttackButton").GetComponent<Button>();
        attack_button.onClick.AddListener(Attack);
    }

    private void Update()
    {
        if (!canAttack)
            Time_delay -= Time.deltaTime;
        if (Time_delay <= 0)
        {
            canAttack = true;
            Time_delay = 0.5f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
            Attack();
    }

    private void Attack()
    {
        if (canAttack && !pl_h.isDie)
        {
            int ran = (int)Random.Range(0f, 10f);
            if(ran <= 5)
            {
                Instantiate(bullet_prefabs, pos_attack1.position, Quaternion.Euler(0, 0, 0));
                Debug.Log("1 vien");
            }
                
            if(ran > 5)
            {
                Instantiate(bullet_prefabs, pos_attack1.position, Quaternion.Euler(0, 0, 0));
                Instantiate(bullet_prefabs, pos_attack2.position, Quaternion.Euler(0, 0, 0));
                Debug.Log("2 vien"); 
            }          
            canAttack = false;
        }
    }
}
