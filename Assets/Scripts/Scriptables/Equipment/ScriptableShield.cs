using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shield", menuName = "RPG/Equipment/Shield")]
public class ScriptableShield : ScriptableEquipment
{
    public int ACModifier;

    public override string Description()
    {
        return $"+{ACModifier} AC";
    }
}
