using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableUnitBase : ScriptableObject
{
    public Faction Faction;
    public string Name;
    public Sprite Sprite;

    [SerializeField] private Stats _stats;
    public Stats BaseStats => _stats;
}

[Serializable]
public struct Stats
{
    public int Strength;
    public int Dexterity;
    public int Constitution;
    public int Intelligence;
    public int Wisdom;
    public int Charisma;
}

[Serializable]
public enum Faction
{
    Hero,
    NPC
}
