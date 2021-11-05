using System.Collections.Generic;
using UnityEngine;

public class DetectionSight : MonoBehaviour
{
    public string enemyTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(enemyTag))
        {
            AddTargetToEnemyQueue(GetComponent<TowerLogic>().enemyUnitQueue, collision.gameObject.GetComponent<Unit>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            RemoveTargetToEnemyQueue(GetComponent<TowerLogic>().enemyUnitQueue);
        }
    }

    public void AddTargetToEnemyQueue(Queue<Unit> queue, Unit unit)
    {
        queue.Enqueue(unit);
    }

    public void RemoveTargetToEnemyQueue(Queue<Unit> queue)
    {
        Debug.Log("Remove Unit!");
        queue.Dequeue();
    }

}