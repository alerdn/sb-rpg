using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Class", menuName = "RPG/Class")]
public class ScriptableClass : ScriptableObject
{
    public int MaxHP;
    public List<Ability> Abilities;
}
