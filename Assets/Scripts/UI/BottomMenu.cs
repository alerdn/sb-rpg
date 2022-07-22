using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomMenu : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private CharacterSheet _caracterSheet;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private GameObject _ability;

    [Header("Buttons")]
    [SerializeField] private Button _sheetBtn;
    [SerializeField] private Button _inventoryBtn;
    [SerializeField] private Button _abilityBtn;

    private List<GameObject> components;

    private void Start()
    {
        components = new List<GameObject>()
        {
            _caracterSheet.gameObject,
            _inventory.gameObject,
            //_ability.gameObject
        };

        _sheetBtn.onClick.AddListener(() => ToggleComponent(_caracterSheet.name));
        _inventoryBtn.onClick.AddListener(() => ToggleComponent(_inventory.name));
        // _abilityBtn.onClick.AddListener(() => ToggleComponent(_ability.name));
    }

    private void ToggleComponent(string name)
    {
        foreach (GameObject component in components)
        {
            component.SetActive(component.name == name && !component.activeSelf);
        }
    }
}
