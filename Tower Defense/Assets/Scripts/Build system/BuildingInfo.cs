﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "ScriptableObjects/BuildingInfo", order = 0)]
public class BuildingInfo : ScriptableObject
{
    [SerializeField] List<Stat> Stats = null;

    [Header("Debug")]
    [SerializeField] public List<Stat> currentStats = new List<Stat>();

    [SerializeField] protected Pool buildingPool = null;
    [SerializeField] protected Pool buildingBlueprintPool = null;

    public Pool GetBuildingPool() { return buildingPool; }
    public Pool GetBuildingBlueprintPool() { return buildingBlueprintPool; }

    public float GetStat(StatType type) {
        for (int i = 0; i < currentStats.Count; i++)
        {
            if (currentStats[i].Type == type)
            {
                return currentStats[i].Value;
            }
        }
        Debug.LogError("There is no " + type + " on " + name);
        return 0f;
    }

    public void IncrementStat(StatType type, float increment)
    {
        for (int i = 0; i < currentStats.Count; i++)
        {
            if(currentStats[i].Type == type)
            {
                if(currentStats[i].Value + increment > Stats[i].Value * 0.1f)
                    currentStats[i] = new Stat(type, currentStats[i].Value + increment);
            }
        }
    }

    void OnEnable()
    {
        resetCurrentStats();
    }

    void resetCurrentStats()
    {
        currentStats.Clear();
        foreach (Stat stat in Stats)
        {
            currentStats.Add(stat);
        }
    }
}
