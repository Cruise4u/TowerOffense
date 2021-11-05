using System;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Vector2[] waypointArray;
    public LineRenderer pathLine;
    public Queue<Vector2> waypointQueue;

    public void Start()
    {
        Init();
    }

    public void Init()
    {
        SetPath();
    }

    public void SetPath()
    {
        pathLine = GetComponent<LineRenderer>();
        waypointArray = new Vector2[pathLine.positionCount];
        waypointQueue = new Queue<Vector2>();
        for (int i = 0; i < pathLine.positionCount; i++)
        {
            Vector3 localToWorldPosition = transform.TransformPoint(pathLine.GetPosition(i));
            waypointArray[i] = localToWorldPosition; 
            waypointQueue.Enqueue(waypointArray[i]);
        }
    }
}
