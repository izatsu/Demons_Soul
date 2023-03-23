using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 6;
    public int amorr = 5;
    public bool isDie = false;

    Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Bullet_enemy"))
        {
            if (amorr > 0)
            {
                amorr--;
                return;
            }
                
            if (amorr <= 0)
            {
                health--;
                if(health <= 0)
                {
                    isDie = true;
                    ani.SetBool("isDie", true);                           
                }
            }
                

        }
            

    }
}
