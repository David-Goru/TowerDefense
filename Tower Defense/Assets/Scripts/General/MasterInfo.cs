﻿using UnityEngine;

/// <summary>
/// Stores information of the game loop
/// </summary>
[CreateAssetMenu(fileName = "MasterInfo", menuName = "ScriptableObjects/MasterInfo", order = 0)]
public class MasterInfo : ScriptableObject
{
    [SerializeField] float initialBalance = 0.0f;
    [SerializeField] BuildingInfo[] turretsSet = null;
    [SerializeField] BuildingInfo[] initialTurretsSet = null;
    [SerializeField] Upgrade[] upgradesSet = null;
    [SerializeField] Pool[] enemiesSet = null;

    float currentBalance = 0.0f;

    public float Balance { get => currentBalance; set => currentBalance = value; }
    public Upgrade[] UpgradesSet { get => upgradesSet; }

    public BuildingInfo[] GetTurretsSet() { return turretsSet; }
    public BuildingInfo[] GetInitialTurretsSet() { return initialTurretsSet; }
    public Pool[] GetEnemiesSet() { return enemiesSet; }

    void resetBalance() { currentBalance = initialBalance; }

    public void InitializeVariables()
    {
        resetBalance();
    }
}