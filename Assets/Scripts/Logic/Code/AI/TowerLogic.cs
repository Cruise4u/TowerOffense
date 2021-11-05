using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerLogic : MonoBehaviour
{
    public IDamage damageDealer;
    public Queue<Unit> enemyUnitQueue;
    public Unit enemyUnit;

    public void Init()
    {
        enemyUnitQueue = new Queue<Unit>();
        damageDealer = GetComponent<DamageDealerLogic>();
    }

    public void GetFirstEnemyOnQueue()
    {
        enemyUnit = enemyUnitQueue.Peek();
    }

    public bool IsEnemyOnSight()
    {
        if(enemyUnitQueue != null && enemyUnitQueue.Count > 0)
        {
            return true;       
        }
        else
        {
            Debug.Log("There's no enemies around!");
            return false;
        }
    }

    public void ShootAtTarget()
    {
        damageDealer.DealDamage(enemyUnit);
    }


}


