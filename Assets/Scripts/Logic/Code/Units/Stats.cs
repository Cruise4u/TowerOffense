using System;
using UnityEditor;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public StatsData statsData;

    public int currentHealth { get; set; }
    public int maxHealth { get; set; }
    public int attackDamage { get; set; }
    public int attackSpeed { get; set; }
    public int movementSpeed { get; set; }
    public int armor { get; set; }

    public void SetStats(StatsData statsData)
    {
        currentHealth = statsData.maxHealth;
        attackDamage = statsData.attackDamage;
        attackSpeed = statsData.attackSpeed;
        movementSpeed = statsData.movementSpeed;
        armor = statsData.armor;
    }


}