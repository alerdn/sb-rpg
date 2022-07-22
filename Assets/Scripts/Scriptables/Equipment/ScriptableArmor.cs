using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor", menuName = "RPG/Equipment/Armor")]
public class ScriptableArmor : ScriptableEquipment
{
    public int BaseAC;
    public bool AccumulativeAC;
    public int AccumulativeCap;

    public int GetAC(int dexterity)
    {
        if (AccumulativeAC)
        {
            if (AccumulativeCap == 0)
                return BaseAC + dexterity;
            else
                return BaseAC + (dexterity > AccumulativeCap ? AccumulativeCap : dexterity);
        }
        else return BaseAC;
    }
}
