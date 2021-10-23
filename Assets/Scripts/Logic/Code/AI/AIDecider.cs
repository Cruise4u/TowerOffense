using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIDecider : MonoBehaviour
{
    public IPointOfInterest poi;
    public Path path;
    public NavMeshAgent agent;
    Queue<Vector2> waypointQueue;


    public float speed;
    public float distanceToTarget;
    public Vector2 targetPosition;
    public int wayPointIndex;

    public void Init()
    {
        SetPath();
        SetEnemyBasePoint();
        SetNavAgent();
        wayPointIndex = 0;
        targetPosition = path.wayPointArray[wayPointIndex];
    }


    public void SetPath()
    {
        path = FindObjectOfType<Path>();
        waypointQueue = new Queue<Vector2>();
        if (waypointQueue.Count != 0)
        {
            waypointQueue.Clear();
        }
        var roadWaypoints = path.wayPointArray;
        for (int i = 0; i < roadWaypoints.Length; i++)
        {
            waypointQueue.Enqueue(roadWaypoints[i]);
        }
    }
    public void SetEnemyBasePoint()
    {
        poi = GetExitPointRandomly();
    }
    public void SetNavAgent()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    public void SetNextWaypointAsTarget()
    {
        waypointQueue.Dequeue();
    }

    public void MoveTowardsWaypoint(Vector2 point)
    {
        Debug.Log(point);
        if(agent.destination != new Vector3(point.x,point.y,0))
        {
            agent.destination = point;
        }
    }

    public void MoveToNextWaypoint()
    {
        Vector2 directionToTarget = targetPosition - new Vector2(transform.position.x, transform.position.y);
        transform.position += new Vector3(directionToTarget.x, directionToTarget.y, 0) * Time.deltaTime * speed;
        distanceToTarget = Vector2.Distance(transform.position, targetPosition);
    }

    public bool IsUnitOnProximityToWaypoint(Vector2 point)
    {
        var distance = Vector2.Distance(transform.position, point);
        if(distance <= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UpdateWayPointPath()
    {
        if(distanceToTarget <= 1.0f)
        {
            if(wayPointIndex != path.wayPointArray.Length)
            {
                wayPointIndex += 1;
                targetPosition = path.wayPointArray[wayPointIndex];
            }
        }
    }

    public Vector2 GetCurrentWayPointAsTarget()
    {
        return waypointQueue.Peek();
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
}
