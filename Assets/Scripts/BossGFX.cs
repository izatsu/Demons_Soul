using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BossGFX : MonoBehaviour
{
    AIPath aipath;
    AIDestinationSetter aid;

    public int max_health = 100;
    public int count_health = 0;


   


    Animator ani;

    private bool isFacingRight = true;


    public GameObject bulletPrefab;
    public float bulletSpeed = 10.0f;
    float nextFireTime = 3f;
    public float fireRate = 3f;

    HealthBar healthbar;

    bool isSleep = true;
    float count_exitSleep = 2;

    float time_attack = 2f;

    private void Start()
    {
        ani = GetComponent<Animator>();
        aipath = GetComponent<AIPath>();
        healthbar = GameObject.Find("HealthBarBoss").GetComponent<HealthBar>();
        healthbar.SetMaxHealth(max_health);
        aid = GetComponent<AIDestinationSetter>();
        aid.target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (isSleep)
        {
            aipath.maxSpeed = 0;
            Debug.Log("isSleep");
        }
        else
        {
            Debug.Log("!isSleep");
            aipath.maxSpeed = 4;
            ani.SetBool("isSleep", false);
        } 
            
            
        

        Flip();

        if(aid.target != null)
        {
            if (Vector2.Distance(transform.position, aid.target.position) <= 5f && !isSleep)
            {

                ani.SetBool("isAttack", true);
                /*if (Time.time > nextFireTime)
                {
                    Fire();
                    nextFireTime = Time.time + 1f / fireRate;                  
                }*/
            }
            else
            {
                ani.SetBool("isAttack", false);
            }

            if(!isSleep)
            {
                time_attack -= Time.deltaTime;
                if (time_attack <= 0)
                {
                    time_attack = 2f;
                    Fire();
                }
            }    
           
                
        }    
        

    }


    void Fire()
    {
        for (int i = 0; i < 8; i++)
        {
            float angle = i * Mathf.PI / 4f;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }

    private void Flip()
    {
        if (isFacingRight && aipath.desiredVelocity.x < 0f || !isFacingRight && aipath.desiredVelocity.x > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletPlayer"))
        {
            Destroy(collision.gameObject);
            count_exitSleep--;
            if (count_exitSleep <= 0)
                isSleep = false;

            if (!isSleep)
            {
                count_health += 2;
                healthbar.SetHealth(max_health - count_health);

            }

            if (count_health >= max_health)
                Destroy(gameObject);                    
        }
    }
}
