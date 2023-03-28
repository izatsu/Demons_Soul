using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyBullet", 1.5f);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }*/
}
