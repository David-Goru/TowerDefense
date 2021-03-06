﻿using UnityEditor;
using UnityEngine;

/// <summary>
/// This is a class
/// </summary>

public enum StatType { PRICE, MAXHEALTH, DAMAGE, ATTACKRANGE, ATTACKRATE};

[System.Serializable]
public struct Stat
{
    [SerializeField] StatType type;
    [SerializeField] float value;

    public float Value { get => value; set => this.value = value; }

    public StatType Type { get => type; }

    public Stat(StatType statType, float statValue)
    {
        type = statType;
        value = statValue;
    }

    public void SetValue(float value)
    {
        this.value = value;
    }
}