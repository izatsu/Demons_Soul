using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet_Dökkálfar : MonoBehaviour
{
    private Transform player;
    private bool isFacingRight = true;
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        flip();
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
    private void flip()
    {
        Vector3 direction = player.position - transform.position;

        if ((isFacingRight && direction.x < 0) || (!isFacingRight && direction.x > 0))
        {
            Debug.Log("Da flip");
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
