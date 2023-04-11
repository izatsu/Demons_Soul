using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour
{
    public Transform lineRendererTransform;
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = lineRendererTransform.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
    }

    private void Update()
    {
        Vector3 start = transform.position;
        Vector3 end = transform.position + transform.forward * 10f;

        RaycastHit hit;
        if (Physics.Raycast(start, transform.forward, out hit, 10f))
        {
            if (hit.collider.gameObject.tag == "Obstacle")
            {
                end = hit.point;
                lineRenderer.enabled = true;
            }
            else
            {
                lineRenderer.enabled = false;
            }
        }
        else
        {
            lineRenderer.enabled = false;
        }

        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}
