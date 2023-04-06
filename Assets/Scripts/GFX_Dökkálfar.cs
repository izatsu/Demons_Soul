using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFX_Dökkálfar : MonoBehaviour
{
    public int Dökkálfar_health = 50;
    public int countDökkálfar_health = 0;

    Animator ani;
    public bool checkDie = false;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    void DestroyBoss()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletPlayer"))
        {
            countDökkálfar_health++;
            Destroy(collision);
            if(countDökkálfar_health >= Dökkálfar_health)
            {
                checkDie = true;
                ani.SetBool("die", true);
                Invoke("DestroyBoss", 2f);
            }                            
        }
    }
}
