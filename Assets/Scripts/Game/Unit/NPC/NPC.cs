using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPC : UnitBase
{
    [SerializeField] private ScriptableNPC _npc;

    private void Start()
    {
        Faction = _npc.Faction;
        Name = _npc.Name;
        Race = _npc.Race;
        Stats = CalculateStats(_npc.BaseStats, Race);

        MaxHP = _npc.MaxHP;
        HP = MaxHP;

        Inventory = _npc.Inventory;

        CurrentArmor = Armors().ToList()[0];
        CurrentWeapon = Weapons().ToList()[0];
        CurrentShield = Shields().ToList()[0];

        Abilities = _npc.Abilities;
        AC = GetAC();
    }

    private void PrintInfo()
    {
        Debug.Log($"Strengh: {Stats.Strength} ({AttributeModifier(Stats.Strength)})");
        Debug.Log($"Dexterity: {Stats.Dexterity} ({AttributeModifier(Stats.Dexterity)})");
        Debug.Log($"Constitution: {Stats.Constitution} ({AttributeModifier(Stats.Constitution)})");
        Debug.Log($"Intelligence: {Stats.Intelligence} ({AttributeModifier(Stats.Intelligence)})");
        Debug.Log($"Wisdom: {Stats.Wisdom} ({AttributeModifier(Stats.Wisdom)})");
        Debug.Log($"Charisma: {Stats.Charisma} ({AttributeModifier(Stats.Charisma)})");

        Debug.Log($"AC: {AC}");
        Debug.Log($"Max HP: {MaxHP}");
    }
}
