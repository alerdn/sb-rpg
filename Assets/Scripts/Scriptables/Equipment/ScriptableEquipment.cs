using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableEquipment : ScriptableObject
{
    public Sprite Sprite;
    public bool IsEquipped;
    public abstract string Description();
}
