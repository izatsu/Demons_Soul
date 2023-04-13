using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class animalController : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] Transform[] pointTarget;
    [SerializeField] float timeCanMove = 3f;
    [SerializeField] bool hasPlayer = false;
    [SerializeField] GameObject ItemHeal_Prefab;


    Transform pos;


    AIPath aipath;
    AIDestinationSetter aid;

    private bool isFacingRight = true;

  

    Animator ani;
    Transform player;
    

    int maxhealth = 5;
    int currenthealth = 0;




    void Start()
    {
        aipath = GetComponent<AIPath>();
        aid = GetComponent<AIDestinationSetter>();
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

        pos = GetRandomTarget();
        aid.target = pos;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        currenthealth = maxhealth;

    }

    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) <= 5f)
                hasPlayer = true;
            else hasPlayer = false;
        }
        else hasPlayer = false;
        

        if(!hasPlayer)
        {
            aid.target = pos;
            if (Vector2.Distance(transform.position, pos.position) <= 0.5f)
            {
                ani.SetBool("isRun", false);
                timeCanMove -= Time.deltaTime;
            }
            else
            {
                ani.SetBool("isRun", true);
                timeCanMove = 3f;
            }

            if (timeCanMove <= 0)
            {
                pos = GetRandomTarget();
                aid.target = pos;
                timeCanMove = 3f;
            }
        }    
        else
        {
            aid.target = player;
            if (Vector2.Distance(transform.position, player.position) <= 0.5f)
            {
                ani.SetBool("isAttack", true);
                
            }
            else
            {
                
                ani.SetBool("isRun", true);
                ani.SetBool("isAttack", false);

            }
           
        }
        
            
            
        Flip();
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

    private Transform GetRandomTarget()
    {
        int ran = Random.Range(0, pointTarget.Length);
        return pointTarget[ran];
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("BulletPlayer"))
        {
            Destroy(collision.gameObject);
            currenthealth--; 
            if(currenthealth <= 0)
            {
                aipath.maxSpeed = 0;
                ani.SetBool("isDie", true);
                Invoke("DestroyAn", 1f);
            }
        }
    }

    void DestroyAn()
    {
        int ran = Random.Range(0, 20);
        if (ran <= 7)
        {
            GameObject item = Instantiate(ItemHeal_Prefab, transform.position, Quaternion.Euler(0, 0, 0));
            item.GetComponent<SpriteRenderer>().sortingLayerName = gameObject.GetComponent<SpriteRenderer>().sortingLayerName;
            item.layer = gameObject.layer;
        }    
            

        Destroy(gameObject);
    }
}
