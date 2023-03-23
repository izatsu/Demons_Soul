using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Transform pos_attack;
    [SerializeField] GameObject bullet_prefabs;
    private float Time_delay = 0.5f;
    private bool canAttack = true;

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

    public void Attack()
    {
        if (canAttack)
        {
            Instantiate(bullet_prefabs, pos_attack.position, Quaternion.Euler(0, 0, 0));
            canAttack = false;
        }
    }
}
