using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Hero : UnitBase, IAttacker, IDamageable
{
    public event Action OnLevelUp;

    [SerializeField] private ScriptableHero _hero;
    [SerializeField] private SpriteRenderer _renderer;

    public ScriptableClass Class { get; private set; }
    public bool IsLevelingUp { get; private set; } = false;
    public int Level { get; private set; }
    public int ExperienceAmount
    {
        get => _experienceAmount;
        private set
        {
            _experienceAmount = value;
            if (_experienceAmount >= HeroManager.LevelDictonary[Level])
            {
                // Level Up
                OnLevelUp?.Invoke();

                foreach (var pair in HeroManager.LevelDictonary)
                {
                    if (_experienceAmount < pair.Value)
                    {
                        Level = pair.Key;
                        break;
                    }
                }
            }
        }
    }

    private int _experienceAmount;

    private void Awake()
    {
        Faction = _hero.Faction;
        Name = _hero.Name;
        Sprite = _hero.Sprite;
        Class = Instantiate(_hero.Class);
        Race = Instantiate(_hero.Race);
        Stats = CalculateStats(_hero.BaseStats, Race);
        Level = _hero.Level;
        ExperienceAmount = _hero.ExperienceAmount;

        MaxHP = GetMaxHP();
        HP = MaxHP;

        Inventory = new List<ScriptableEquipment>();
        foreach (var equip in _hero.Inventory)
        {
            Inventory.Add(Instantiate(equip));
        }
        CheckEquipments();

        Abilities = Class.Abilities;
        AC = GetAC();
    }

    private void Start()
    {
        _renderer.sprite = _hero.Sprite;
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExperienceAmount += 50;
        }
#endif
    }

    public void CollectEquipment(ScriptableEquipment equipment)
    {
        Inventory.Add(Instantiate(equipment));
    }

    private void CheckEquipments()
    {
        foreach (var item in Inventory)
        {
            if (item.IsEquipped)
            {
                Equip(item);
            }
        }
    }

    public bool CanEquip(ScriptableEquipment equipment)
    {
        return equipment.Classes.Any(c => c == Class.Name);
    }

    public bool Equip(ScriptableEquipment equipment)
    {
        if (!CanEquip(equipment)) return false;

        if (equipment is ScriptableArmor)
        {
            // Setting 'false' to the previous equipped item
            if (CurrentArmor != null) CurrentArmor.IsEquipped = false;
            CurrentArmor = equipment as ScriptableArmor;
        }
        if (equipment is ScriptableWeapon)
        {
            if (CurrentWeapon != null) CurrentWeapon.IsEquipped = false;
            CurrentWeapon = equipment as ScriptableWeapon;
        }
        if (equipment is ScriptableShield)
        {
            if (CurrentShield != null) CurrentShield.IsEquipped = false;
            CurrentShield = equipment as ScriptableShield;
        }

        equipment.IsEquipped = true;
        return true;
    }

    public void Unequip(ScriptableEquipment equipment)
    {
        if (equipment is ScriptableArmor) CurrentArmor = null;
        if (equipment is ScriptableWeapon) CurrentWeapon = null;
        if (equipment is ScriptableShield) CurrentShield = null;

        equipment.IsEquipped = false;
    }

    private int GetMaxHP()
    {
        return Class.MaxHP + AttributeModifier(Stats.Constitution);
    }

    #region Interfaces Implementations

    public void Damage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Debug.Log("inconsciente");
        }
    }

    public void Attack(IDamageable target)
    {
        int damage = CurrentWeapon.Attack(AttributeModifier(Stats.Strength));
        target.Damage(damage);
    }

    #endregion
}
