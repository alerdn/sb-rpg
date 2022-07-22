using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : Singleton<HeroManager>
{
    [SerializeField] private Hero _hero;

    public Hero Hero { get => _hero; }

    public static Dictionary<int, int> LevelDictonary = new Dictionary<int, int>() {
        { 0, 0 },
        { 1, 300 },
        { 2, 900 },
        { 3, 2700 },
        { 4, 6500 },
        { 5, 14000 },
    };
}
