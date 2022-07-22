using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitBase : MonoBehaviour
{
    /* Stats */
    public Faction Faction { get; protected set; }
    public string Name { get; protected set; }
    public Sprite Sprite { get; protected set; }
    public Stats Stats { get; protected set; }
    public ScriptableRace Race { get; protected set; }
    public List<Ability> Abilities { get; protected set; }

    public int AC { get; protected set; }
    public int MaxHP { get; protected set; }
    public int HP { get; protected set; }

    /* Equipments */
    public List<ScriptableEquipment> Inventory { get; protected set; }

    /* Equipped equipments */
    public ScriptableArmor CurrentArmor { get; protected set; }
    public ScriptableWeapon CurrentWeapon { get; protected set; }
    public ScriptableShield CurrentShield { get; protected set; }

    protected Stats CalculateStats(Stats _stats, ScriptableRace _race)
    {
        Stats finalStats;
        finalStats.Strength = _stats.Strength + _race.BonusStrength;
        finalStats.Dexterity = _stats.Dexterity + _race.BonusDexterity;
        finalStats.Constitution = _stats.Constitution + _race.BonusConstitution;
        finalStats.Intelligence = _stats.Intelligence + _race.BonusIntelligence;
        finalStats.Wisdom = _stats.Wisdom + _race.BonusWisdom;
        finalStats.Charisma = _stats.Charisma + _race.BonusCharisma;

        return finalStats;
    }

    protected IEnumerable<ScriptableArmor> Armors()
    {
        foreach (var equip in Inventory)
        {
            if (equip is ScriptableArmor armor)
                yield return armor;
        }
    }
    protected IEnumerable<ScriptableWeapon> Weapons()
    {
        foreach (var equip in Inventory)
        {
            if (equip is ScriptableWeapon weapon)
                yield return weapon;
        }
    }

    protected IEnumerable<ScriptableShield> Shields()
    {
        foreach (var equip in Inventory)
        {
            if (equip is ScriptableShield shield)
                yield return shield;
        }
    }

    public int GetAC()
    {
        int totalCA = 10;
        if (CurrentArmor != null)
        {
            totalCA = CurrentArmor.GetAC(AttributeModifier(Stats.Dexterity));
        }

        if (CurrentShield != null)
        {
            totalCA += CurrentShield.CAModifier;
        }

        return totalCA;
    }

    public int AttributeModifier(int attribute)
    {
        return (attribute - 10) / 2;
    }
}
