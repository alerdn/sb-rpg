using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Equippeds")]
    [SerializeField] private ItemSlot _weaponEquipped;
    [SerializeField] private ItemSlot _armorEquipped;
    [SerializeField] private ItemSlot _shieldEquipped;

    [Header("Action")]
    [SerializeField] private GameObject _actionArea;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemDescription;
    [SerializeField] private Button _equipBtn;
    [SerializeField] private Button _dropBtn;

    [Header("Inventory")]
    [SerializeField] private GameObject inventoryGrid;
}
