using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 6;
    public int amorr = 5;
    public bool isDie = false;

    //kt bị nhận sát thương không 
    private float time_dontHurt = 0;
    private float time_amorr = 0;


    Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }


    private void Update()
    {

        time_dontHurt += Time.deltaTime;
        Debug.Log("Time: " + time_dontHurt);
        if (time_dontHurt >= 5)
        {
            if (amorr < 5)
            {
                time_amorr += Time.deltaTime;
                if (time_amorr >= 1)
                {
                    amorr++;
                    time_amorr = 0;
                }

            }

        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Bullet_enemy"))
        {
            time_dontHurt = 0;
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
