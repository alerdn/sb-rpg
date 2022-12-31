using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableEquipment : ScriptableObject
{
    public string Name { get => name.Replace("(Clone)", ""); }
    public Sprite Sprite;
    public bool IsEquipped;
    public abstract string Description();
    public List<Class> Classes;
}
