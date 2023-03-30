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


    public int splitCount = 0; // số lượng tách
    private int maxSplits = 6; // số lượng tối đa được tách


    Animator ani;

    private bool isFacingRight = true;


    public GameObject bulletPrefab;
    public float bulletSpeed = 10.0f;
    float nextFireTime = 3f;
    public float fireRate = 3f;

    HealthBar healthbar;

    bool isSleep = true;

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
            aipath.maxSpeed = 3;
            ani.SetBool("isSleep", false);
        } 
            
            
        

        Flip();

        if (Vector2.Distance(transform.position, aid.target.position) <= 5f && !isSleep)
        {

            ani.SetBool("isAttack", true);
            if (Time.time > nextFireTime)
            {
                Fire();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
        else
        {
            ani.SetBool("isAttack", false);
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
            isSleep = false;

            if (!isSleep)
            {
                count_health += 2;
                healthbar.SetHealth(max_health - count_health);
                
            }

            Destroy(collision.gameObject);


            if (splitCount < maxSplits && count_health >= max_health)
            {
                splitCount += 2;
                float localx = transform.localScale.x;
                if (transform.localScale.x < 0)
                    localx = transform.localScale.x * -1;

                GameObject newEnemy1 = Instantiate(gameObject, transform.position + new Vector3(-1, 2, 0), Quaternion.Euler(0, 0, 0));
                GameObject newEnemy2 = Instantiate(gameObject, transform.position + new Vector3(-1, -2, 0), Quaternion.Euler(0, 0, 0));

                newEnemy1.GetComponent<BossGFX>().count_health = 0;
                newEnemy2.GetComponent<BossGFX>().count_health = 0;

                newEnemy1.GetComponent<BossGFX>().max_health -= 10;
                newEnemy2.GetComponent<BossGFX>().max_health -= 10;

                Destroy(gameObject);

                newEnemy1.transform.localScale = new Vector3(localx - 0.3f,
                                                             gameObject.transform.localScale.y - 0.3f,
                                                             gameObject.transform.localScale.z - 0.3f);

                newEnemy2.transform.localScale = new Vector3(localx - 0.3f,
                                                             gameObject.transform.localScale.y - 0.3f,
                                                             gameObject.transform.localScale.z - 0.3f);


                newEnemy1.GetComponent<BossGFX>().aipath.maxSpeed += 0.3f;
                newEnemy2.GetComponent<BossGFX>().aipath.maxSpeed += 0.3f;

                newEnemy1.GetComponent<BossGFX>().count_health = 0;
                newEnemy2.GetComponent<BossGFX>().count_health = 0;
            }



            if (count_health >= max_health)
                Destroy(gameObject);
        }
    }
}
