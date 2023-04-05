using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Dökkálfar : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyBullet", 2f);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            DestroyBullet();
    }
}
