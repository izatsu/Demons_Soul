using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    private Transform target;

    private void Start()
    {

        Invoke("delay", 0.1f);

    }

    void delay()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    } 
        

    private void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        /*else
            target = GameObject.FindGameObjectWithTag("Player").transform;*/
    }
}
