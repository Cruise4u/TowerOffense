using System;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Vector2[] wayPointArray;
    public LineRenderer pathLine;

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
        wayPointArray = new Vector2[pathLine.positionCount];
        for (int i = 0; i < pathLine.positionCount; i++)
        {
            Vector3 localToWorldPosition = transform.TransformPoint(pathLine.GetPosition(i));
            wayPointArray[i] = localToWorldPosition;
        }
    }

}
