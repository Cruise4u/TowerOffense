using System.Collections;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    public float speed;
    public float distanceToTarget;
    public int wayPointsCount;
    private Vector2 targetPosition;

    //public IEnumerator MoveThroughPathwayRoutine()
    //{
    //    for (int i = 0; i < pathCreator.bezierPath.NumPoints; i++)
    //    {
    //        var localToWorldPoint = pathCreator.transform.TransformPoint(pathCreator.bezierPath.GetPoint(i));
    //        targetPosition = localToWorldPoint;
    //        Debug.Log("Moving to new path vertex number :" + i);
    //        yield return new WaitUntil(() => distanceToTarget <= 1.0f);
    //    }
    //    Debug.Log("Going out of the loop");
    //}

    public void MoveAtConstantSpeed()
    {
        Vector2 directionToTarget = targetPosition - new Vector2(transform.position.x, transform.position.y);
        transform.position += new Vector3(directionToTarget.x, directionToTarget.y, 0) * Time.deltaTime * speed;
        distanceToTarget = Vector2.Distance(transform.position, targetPosition);
    }

    public void SetCurrentWayPointDirection()
    {

    }


}
