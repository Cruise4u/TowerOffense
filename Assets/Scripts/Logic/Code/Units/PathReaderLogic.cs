using System;
using System.Collections.Generic;
using UnityEngine;

public class PathReaderLogic : MonoBehaviour
{
    public Path path;
    public int waypointIndex;
    public IPointOfInterest poi;
    public Queue<Vector2> pathQueue;

    public void GetPath(Queue<Vector2> queue)
    {
        path = FindObjectOfType<Path>();
        pathQueue = queue;
    }
    public void GetNextWayPoint()
    {
        pathQueue.Dequeue();
    }
    public void UpdatePath(float distance, float threshold, Vector2 direction)
    {
        if (distance <= threshold)
        {
            if (waypointIndex != path.waypointArray.Length)
            {
                waypointIndex += 1;
                direction = path.waypointArray[waypointIndex];
            }
        }
    }
    public void SetEnemyBasePoint()
    {
        poi = GetExitPointRandomly();
    }
    public IPointOfInterest GetExitPointRandomly()
    {
        var poiArray = FindObjectsOfType<PointOfInterrest>();
        var exitPoints = new List<IPointOfInterest>();
        for (int i = 0; i < poiArray.Length; i++)
        {
            if (poiArray[i].poiEnum == POIEnum.Exits)
            {
                exitPoints.Add(poiArray[i]);
            }
        }
        var random = Mathematics.GetRandomValue(exitPoints.Count);
        return exitPoints[random];
    }
    public Vector2 GetCurrentWayPointPosition()
    {
        return pathQueue.Peek();
    }
}
