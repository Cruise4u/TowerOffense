using System;
using UnityEngine;

public class DamageDealerLogic : MonoBehaviour, IDamage
{
    Stats stats;


    public void DealDamage(IDamagable damagable)
    {
        damagable.TakeDamage(stats.attackDamage);
    }
}
