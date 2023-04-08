using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dökkálfar_Controller : MonoBehaviour
{
    private Transform player;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float shootInterval = 0.2f;
    public float bulletDistance = 5f;

    private bool isShooting = false;

    bool isFacingRight = true;
    Rigidbody2D rb;
    GFX_Dökkálfar HealthBoss;
    Vector3 direction = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        HealthBoss = GetComponent<GFX_Dökkálfar>();
    }

    void Update()
    {

        if (!isShooting && !HealthBoss.checkDie)
        {
            StartCoroutine(Shoot());

        }

        flip();
    }

    private void flip()
    {
        if(player != null)
        {
            direction = player.position - transform.position;
        }
        

        if ((isFacingRight && direction.x < 0) || (!isFacingRight && direction.x > 0))
        {
            Debug.Log("Da flip");
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    IEnumerator Shoot()
    {
        isShooting = true;

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 5; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            Vector3 direction = (player.position - transform.position).normalized;

            float angle = Random.Range(-10f, 10f);
            direction = Quaternion.Euler(0, 0, angle) * direction;

            bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;

            yield return new WaitForSeconds(shootInterval);
        }

        isShooting = false;
    }

}
