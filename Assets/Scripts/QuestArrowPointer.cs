using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestArrowPointer : MonoBehaviour
{
    GameObject player;
    public GameObject[] chests;
    public GameObject arrowPrefab;
    public float arrowSpeed = 5f;
    private GameObject[] arrows;

    private void Start()
    {
        player = FindObjectOfType<PlayerMove>().gameObject;
        arrows = new GameObject[chests.Length];
    }

    void Update()
    {   
        if(player != null)
        {
            for (int i = 0; i < chests.Length; i++)
            {
                float distance = Vector3.Distance(player.transform.position, chests[i].transform.position);

                if (distance <= 3f)
                {
                    if (arrows[i] != null)
                    {
                        Destroy(arrows[i]);
                    }
                }
                else if (distance < 30f)
                {
                    if (arrows[i] == null)
                    {
                        arrows[i] = Instantiate(arrowPrefab);
                    }

                    Vector3 direction = (chests[i].transform.position - player.transform.position).normalized;

                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    arrows[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                    arrows[i].transform.position = player.transform.position + direction * 2f;
                    arrows[i].GetComponent<Rigidbody2D>().velocity = direction * arrowSpeed;
                }
                else
                {
                    if (arrows[i] != null)
                    {
                        Destroy(arrows[i]);
                    }
                }
            }
        }       
    }
}
