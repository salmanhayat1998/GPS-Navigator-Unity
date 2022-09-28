using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class GpsHandler : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform From;
    public Transform target;
    [SerializeField] private List<Vector3> points;
    private NavMeshPath path;
    public static bool StartNavigation;
    void Start()
    {
        path = new NavMeshPath();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartNavigation = true;
            lineRenderer.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            StartNavigation = false;
            lineRenderer.enabled = false;
        }

        if (StartNavigation)
        {
            DrawLine();
         
        }
    }


    private void DrawLine()
    {
        if (target != null)
        {
            NavMesh.CalculatePath(From.position, target.position, NavMesh.AllAreas, path);

            if (path.corners.Length > 1)
            {
                int i = 1;
                while (i < path.corners.Length)
                {
                    points = path.corners.ToList();
                    lineRenderer.positionCount = points.Count;
                    for (int j = 0; j < points.Count; j++)
                    {
                        lineRenderer.SetPosition(j, points[j]);
                    }
                    i++;
                }

            }
        }
    }
}
