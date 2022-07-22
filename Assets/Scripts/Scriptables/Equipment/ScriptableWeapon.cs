using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor", menuName = "RPG/Equipment/Weapon")]
public class ScriptableWeapon : ScriptableEquipment
{
    public int DiceAmount;
    public DiceType DiceType;
    public DamageType DamageType;

    /// <summary>
    /// Returns the damage based on the modifier
    /// </summary>
    public int Attack(int modifier)
    {
        int total = 0;
        for (int i = 0; i < DiceAmount; i++)
        {
            total += Random.Range(1, (int)DiceType + 1);
        }

        return total + modifier;
    }
}