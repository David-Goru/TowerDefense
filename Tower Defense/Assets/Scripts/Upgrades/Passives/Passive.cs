﻿using UnityEngine;

/// <summary>
/// This is a class
/// </summary>
/// 
[CreateAssetMenu(fileName = "Passive", menuName = "Upgrades/Passive", order = 0)]
public class Passive : Perk
{
    [SerializeField] string title = "";
    [SerializeField] Stat stat;

    public string Title { get => title; set => title = value; }
    public Stat Stat { get => stat;}
}