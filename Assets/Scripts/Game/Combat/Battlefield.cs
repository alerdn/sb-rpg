using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Battlefield : MonoBehaviour
{
    [SerializeField] private List<Unit> _combatents;
    [SerializeField] private SOInt _currentTurn;
    [SerializeField] private SOString _currentCombatentName;

    [Header("UI")]
    [SerializeField] private Button _atkButton;

    private UnitBase _currentCombatent;

    private void Start()
    {
        StartBattle();
        _atkButton.onClick.AddListener(Attack);
    }

    private void StartBattle()
    {
        _currentCombatent = _combatents[Random.Range(0, 2)].Combatant;
        _currentTurn.value = 1;
        UpdateUI();
    }

    private void Attack()
    {
        string mainAttribute = $"{_currentCombatent.CurrentWeapon.MainAttribute}";
        int attributeScore = (int)_currentCombatent.Stats.GetType().GetField(mainAttribute).GetValue(_currentCombatent.Stats);

        Unit otherCombatant = _combatents.Find((combatant) => combatant.Combatant != _currentCombatent);
        otherCombatant.Combatant.HP -= _currentCombatent.CurrentWeapon.Attack(_currentCombatent.AttributeModifier(attributeScore));

        _currentCombatent = otherCombatant.Combatant;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _currentCombatentName.value = _currentCombatent.Name;
        _combatents.ForEach((currentCombatant) =>
        {
            currentCombatant.CombatantHP.text = $"{currentCombatant.Combatant.HP}/{currentCombatant.Combatant.MaxHP}";
        });
    }
}

[System.Serializable]
public class Unit
{
    public UnitBase Combatant;
    public TMP_Text CombatantHP;
}
