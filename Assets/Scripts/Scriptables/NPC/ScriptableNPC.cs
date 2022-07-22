using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "RPG/Unit/NPC")]
public class ScriptableNPC : ScriptableUnitBase
{
    public ScriptableRace Race;
    public int MaxHP;
    public List<Ability> Abilities;
    public List<ScriptableEquipment> Inventory;
}
