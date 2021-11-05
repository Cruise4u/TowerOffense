using System;
using UnityEngine;

public class Unit : MonoBehaviour,IDamagable
{
    public Stats stats;

    public void TakeDamage(int damage)
    {
        if (stats.currentHealth >= 1)
        {
            stats.currentHealth -= damage;
            //unitUIHandler.DisplayFloatingText("TextPool", damage);
            //unitUIHandler.UpdateHealthValue(stats);
        }
    }

    public bool IsAlive()
    {
        if (stats.currentHealth > 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Defeat()
    {
        Destroy(gameObject);
    }
}
