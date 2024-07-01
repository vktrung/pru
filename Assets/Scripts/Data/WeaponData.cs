using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class WeaponStats
{
    public int damage;
    public float timeToAttack;
    public int numberOfAttack;
    public int numberOfHits;
    public float projectileSpeed;
    public float stun;


    public WeaponStats(WeaponStats stats)
    {
        this.damage = stats.damage;
        this.timeToAttack = stats.timeToAttack;
        this.numberOfAttack = stats.numberOfAttack;
        this.numberOfHits = stats.numberOfHits;
        this.projectileSpeed = stats.projectileSpeed;
        this.stun = stats.stun;
    }

    internal void Sum(WeaponStats weaponUpgradeStats)
    {
        this.damage += weaponUpgradeStats.damage;
        this.timeToAttack += weaponUpgradeStats.timeToAttack;
        this.numberOfAttack += weaponUpgradeStats.numberOfAttack;
        this.numberOfHits += weaponUpgradeStats.numberOfHits;
        this.projectileSpeed += weaponUpgradeStats.projectileSpeed;
        this.stun += weaponUpgradeStats.stun;
    }
}

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string Name;
    public WeaponStats stats;
    public GameObject weaponBasePrefabs;
    public List<UpGradeData> upgrades;
}
