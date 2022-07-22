using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Race", menuName = "RPG/Race")]
public class ScriptableRace : ScriptableObject
{
    public int BonusStrength;
    public int BonusDexterity;
    public int BonusConstitution;
    public int BonusIntelligence;
    public int BonusWisdom;
    public int BonusCharisma;
}
