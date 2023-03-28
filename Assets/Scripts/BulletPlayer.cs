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

    SpriteRenderer sp_bullet;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        find = FindObjectOfType<PlayerFindEnemy>().GetComponent<PlayerFindEnemy>();
        pl_move = FindObjectOfType<PlayerMove>().GetComponent<PlayerMove>();
        sp_bullet = GetComponent<SpriteRenderer>();

        sp_bullet.sortingLayerName = pl_move.GetComponent<SpriteRenderer>().sortingLayerName;

        pos_start = transform.position;

        if ((find.direction_attack != null) && (Vector2.Distance(pos_start, find.direction_attack.position) < 8f))
            pos_enemy = find.direction_attack;
        else
            pos_enemy = null;

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
