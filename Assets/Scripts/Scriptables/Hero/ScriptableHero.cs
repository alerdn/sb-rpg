using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hero", menuName = "RPG/Unit/Hero")]
public class ScriptableHero : ScriptableUnitBase
{
    public int Level;
    public int ExperienceAmount;
    public ScriptableClass Class;
    public ScriptableRace Race;
    public List<ScriptableEquipment> Inventory;
}
