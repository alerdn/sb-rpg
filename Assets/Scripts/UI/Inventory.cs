using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Hero _hero;

    [Header("Equippeds")]
    [SerializeField] private ItemSlot _weaponEquipped;
    [SerializeField] private ItemSlot _armorEquipped;
    [SerializeField] private ItemSlot _shieldEquipped;

    [Header("Infos")]
    [SerializeField] private TMP_Text _atk;
    [SerializeField] private TMP_Text _hp;
    [SerializeField] private TMP_Text _ac;

    [Header("Action")]
    [SerializeField] private GameObject _actionArea;
    [SerializeField] private Image _itemSprite;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemDescription;
    [SerializeField] private TMP_Text _classesList;
    [SerializeField] private Button _equipBtn;
    [SerializeField] private Button _dropBtn;

    [Header("Inventory")]
    [SerializeField] private GameObject inventoryGrid;

    private ItemSlot _selectedSlot;
    private Color textColor = new Color(0.2f, 0.2313726f, 0.2862745f);
    private Color alertColor = new Color(1f, 0.3443396f, 0.3443396f);

    private void OnEnable()
    {
        UpdateUI();
    }

    private void Start()
    {
        _hero = HeroManager.Instance.Hero;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (_hero == null) return;
        DisplayItem(null);

        var currWeapon = _hero.CurrentWeapon;
        var currArmor = _hero.CurrentArmor;
        var currShield = _hero.CurrentShield;

        // Equippeds
        _weaponEquipped.Equipment = currWeapon;
        if (_weaponEquipped.Equipment != null) _weaponEquipped.OnItemSelected += DisplayItem;

        _armorEquipped.Equipment = currArmor;
        if (_armorEquipped.Equipment != null) _armorEquipped.OnItemSelected += DisplayItem;

        _shieldEquipped.Equipment = currShield;
        if (_shieldEquipped.Equipment != null) _shieldEquipped.OnItemSelected += DisplayItem;

        // Infos
        if (currWeapon != null)
        {
            string mainAttribute = $"{currWeapon.MainAttribute}";
            int attributeScore = (int)_hero.Stats.GetType().GetField(mainAttribute).GetValue(_hero.Stats);

            _atk.text = $"{currWeapon.DiceAmount}{currWeapon.DiceType} + {_hero.AttributeModifier(attributeScore)}";
        }
        else
        {
            _atk.text = $"{_hero.AttributeModifier(_hero.Stats.Strength) + 1}";
        }
        _hp.text = $"{_hero.HP}/{_hero.MaxHP}";
        _ac.text = _hero.GetAC().ToString();

        // Inventory
        var inventorySlots = inventoryGrid.GetComponentsInChildren<ItemSlot>();
        foreach (var slot in inventorySlots)
        {
            slot.Equipment = null;
            slot.OnItemSelected += DisplayItem;
        }

        var itens = _hero.Inventory.Where(eq => !eq.IsEquipped);

        int i = 0;
        foreach (var item in itens)
        {
            inventorySlots[i].Equipment = item;
            i++;
        }
    }

    private void DisplayItem(ItemSlot slot)
    {
        if (slot != null)
        {
            _selectedSlot = slot;
        }

        if (_selectedSlot != null && _selectedSlot.Equipment != null)
        {
            _actionArea.SetActive(true);
            _itemName.text = _selectedSlot.Equipment.name;
            _itemSprite.sprite = _selectedSlot.Equipment.Sprite;
            _itemDescription.text = _selectedSlot.Equipment.Description();
            _classesList.text = $"classes: {String.Join(", ", _selectedSlot.Equipment.Classes)}";
            if (!_hero.CanEquip(_selectedSlot.Equipment)) _classesList.color = alertColor;
            else _classesList.color = textColor;

            if (_selectedSlot.Equipment.IsEquipped)
            {
                _equipBtn.GetComponentInChildren<TMP_Text>().text = "unequip";
                _equipBtn.onClick.RemoveAllListeners();
                _equipBtn.onClick.AddListener(() => Unequip(_selectedSlot.Equipment));
            }
            else
            {
                _equipBtn.GetComponentInChildren<TMP_Text>().text = "equip";
                _equipBtn.onClick.RemoveAllListeners();
                _equipBtn.onClick.AddListener(() => Equip(_selectedSlot.Equipment));
            }

        }

        _actionArea.SetActive(_selectedSlot != null && _selectedSlot.Equipment != null);
    }

    private void Equip(ScriptableEquipment equipment)
    {
        if (!_hero.Equip(equipment)) return;

        // Deselect slot
        _selectedSlot = null;

        UpdateUI();
    }

    private void Unequip(ScriptableEquipment equipment)
    {
        _hero.Unequip(equipment);
        _selectedSlot.Equipment = null;

        // Deselect slot
        _selectedSlot = null;

        UpdateUI();
    }

    private void OnDisable()
    {
        _selectedSlot = null;

        _weaponEquipped.OnItemSelected -= DisplayItem;
        _armorEquipped.OnItemSelected -= DisplayItem;
        _shieldEquipped.OnItemSelected -= DisplayItem;

        foreach (var item in inventoryGrid.GetComponentsInChildren<ItemSlot>())
        {
            item.OnItemSelected -= DisplayItem;
        }
    }
}
