using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    private Vector2 direction = Vector2.up;
    [SerializeField] float speed;

    private Vector2 pos_start;

    private Transform pos_enemy;

    Rigidbody2D rb;

    PlayerFindEnemy find;

    PlayerMove pl_move;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        find = FindObjectOfType<PlayerFindEnemy>().GetComponent<PlayerFindEnemy>();
        pl_move = FindObjectOfType<PlayerMove>().GetComponent<PlayerMove>();

        pos_start = transform.position;


        pos_enemy = find.direction_attack;

        if (pos_enemy != null)
            direction = (pos_enemy.position - transform.position);
        else
        {
            DestroyImmediate(pos_enemy);
            if (pl_move.direction != Vector2.zero)
                direction = pl_move.direction;
            else
                direction = Vector2.down;
        }
    }


    void Update()
    {

        if (Vector2.Distance(pos_start, transform.position) >= 10f)
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {

        rb.velocity = direction.normalized * speed;
    }

}
