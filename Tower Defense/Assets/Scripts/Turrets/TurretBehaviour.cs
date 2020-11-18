﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour, IPooledObject, IEnemyDamage
{
    [SerializeField] TurretInfo turretInfo = null;
    [SerializeField] EnemyDetection enemyDetection = null;
    [SerializeField] RotationToEnemy rotationToEnemy = null;
    [SerializeField] ShootToEnemy shootToEnemy = null;
    TurretStats turretStats;

    Transform currentEnemy;

    void Start()
    {
        turretStats = new TurretStats(turretInfo);
        enemyDetection.SetRange(turretStats.AttackRange);
        shootToEnemy.SetAttackRate(turretStats.AttackRate);
    }

    void Update()
    {
        updateTarget();
        updateRotation();
        shoot();
    }

    void updateTarget()
    {
        currentEnemy = enemyDetection.UpdateTarget();
    }

    void updateRotation()
    {
        if (currentEnemy != null)
            rotationToEnemy.RotateToEnemy(currentEnemy);
    }

    void shoot()
    {
        if (currentEnemy != null)
            shootToEnemy.ShootEnemy(currentEnemy, turretStats.AttackDamage, this);
        else
        {
            shootToEnemy.ResetTimer();
        }
    }

    public void OnObjectSpawn()
    {
        turretStats = new TurretStats(turretInfo);
        enemyDetection.SetRange(turretStats.AttackRange);
        shootToEnemy.SetAttackRate(turretStats.AttackRate);
    }

    public void OnEnemyHit(float damage)
    {
        turretStats.currentHp -= damage;
        if(turretStats.currentHp <= 0)
        {
            Disable();
        }
    }

    void Disable()
    {
        ObjectPooler.GetInstance().ReturnToThePool(transform);
    }
}
