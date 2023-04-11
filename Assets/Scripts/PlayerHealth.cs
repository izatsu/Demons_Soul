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

    HealthBar healthbar;
    HealthBar Amorrbar;

    private void Start()
    {
        ani = GetComponent<Animator>();
        healthbar = GameObject.Find("Health Bar").GetComponent<HealthBar>();
        Amorrbar = GameObject.Find("Amorr Bar").GetComponent<HealthBar>();

        healthbar.SetMaxHealth(health);
        Amorrbar.SetMaxHealth(amorr);
    }


    private void Update()
    {
        if(!isDie)
        {
            time_dontHurt += Time.deltaTime;
            //Debug.Log("Time: " + time_dontHurt);
            if (time_dontHurt >= 3)
            {
                if (amorr < 5)
                {
                    time_amorr += Time.deltaTime;
                    if (time_amorr >= 1)
                    {
                        amorr++;
                        Amorrbar.SetHealth(amorr);
                        time_amorr = 0;
                    }

                }

            }
        }
        
    }

    private void DestroyP()
    {
        Destroy(gameObject);
    } 
        



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Bullet_enemy"))
        {
            time_dontHurt = 0;
            if (amorr > 0)
            {
                amorr--;
                Amorrbar.SetHealth(amorr);
                return;
            }
                
            if (amorr <= 0)
            {
                health--;
                healthbar.SetHealth(health);
                if(health <= 0)
                {
                    isDie = true;
                    ani.SetBool("isDie", true);
                    Invoke("DestroyP", 2f);
                }
            }          
        }            
    }
}
