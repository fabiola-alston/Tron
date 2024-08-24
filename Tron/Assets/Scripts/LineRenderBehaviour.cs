using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LineRenderBehaviour : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Vector3> points;

    [SerializeField]
    private int colorNum = 0;

    [SerializeField]
    private float width = 1f;


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        points = new List<Vector3>();

        points.Add(transform.position);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());

        width = width / 10;

        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;

        Color color = Color.blue;

        switch (colorNum)
        {
            case 0:
                color = Color.blue;
                break;

            case 1:
                color = new Color(255, 0, 255, 1);
                break;

            case 2:
                color = Color.green;
                break;

            case 3:
                color = Color.yellow;
                break;
        }

        lineRenderer.startColor = color;
        lineRenderer.endColor = color;


    }

    
    void Update()
    {
        Vector3 currentPosition = transform.position;

        if (points.Count == 0 || points[points.Count - 1] != currentPosition)
        {
            points.Add(currentPosition);
            lineRenderer.positionCount = points.Count;
            lineRenderer.SetPositions(points.ToArray());
        }
    }
}
