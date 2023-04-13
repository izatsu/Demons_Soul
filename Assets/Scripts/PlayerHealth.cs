using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //Item
    Button itemButton;
    int count_item = 0;
    [SerializeField] float time_coldown = 2f;
    bool isUseHealth = false;
    CanvasScripts Cs;

    private void Start()
    {
        ani = GetComponent<Animator>();
        healthbar = GameObject.Find("Health Bar").GetComponent<HealthBar>();
        Amorrbar = GameObject.Find("Amorr Bar").GetComponent<HealthBar>();
        healthbar.SetMaxHealth(health);
        Amorrbar.SetMaxHealth(amorr);

        itemButton = GameObject.Find("ItemButton").GetComponent<Button>();
        itemButton.onClick.AddListener(healthButton);
        Cs = Object.FindObjectOfType<CanvasScripts>().GetComponent<CanvasScripts>();
        Cs.Show(count_item);
    }


    private void Update()
    {
        if(!isDie)
        {
            time_dontHurt += Time.deltaTime;

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

            //ButtonHealth
            if(isUseHealth)
            {
                time_coldown -= Time.deltaTime;
            }    
            if(time_coldown <= 0)
            {
                isUseHealth = false;
                time_coldown = 2f;
            }               
        }       
    }

    private void DestroyP()
    {
        Destroy(gameObject);
    } 
        



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Bullet_enemy") || collision.CompareTag("Animal"))
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
        
        if(collision.CompareTag("itemHealth"))
        {
            Debug.Log("da nhat mau");
            Destroy(collision.gameObject);
            if(count_item < 3)
                count_item++;
            Cs.Show(count_item);
        }    
    }

    private void healthButton()
    {
        if(count_item > 0 && health < 6 && !isDie && !isUseHealth)
        {
            Debug.Log("da health");
            if(health == 5)
            {
                health++;
                healthbar.SetHealth(health);
            }
            else
            {
                health += 2;
                healthbar.SetHealth(health);
            } 
            count_item--;
            Cs.Show(count_item);
            isUseHealth = true;
        }
    }    
}
