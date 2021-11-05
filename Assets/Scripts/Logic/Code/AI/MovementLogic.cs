using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLogic : MonoBehaviour
{
    public Stats stats;
    public Path path;
    public float distanceToTarget;
    public Vector2 targetPosition;
    public int wayPointIndex;

    public void Init()
    {
        wayPointIndex = 0;
        targetPosition = path.waypointArray[wayPointIndex];
    }


    public void UpdateDistanceToTarget()
    {
        distanceToTarget = Vector2.Distance(transform.position, targetPosition);
    }

    public void MoveTowardsWaypoint(float speed)
    {
        Vector2 directionToTarget = targetPosition - new Vector2(transform.position.x, transform.position.y);
        transform.position += new Vector3(directionToTarget.x, directionToTarget.y, 0).normalized * Time.deltaTime * speed;
    }



}
