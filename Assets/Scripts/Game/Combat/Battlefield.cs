using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Battlefield : Singleton<Battlefield>
{
    public UnitBase CurrentCombatent { get; private set; }

    [SerializeField] private List<Unit> _combatents;
    [SerializeField] private SOInt _currentTurn;
    [SerializeField] private SOString _currentCombatentName;

    [Header("UI")]
    [SerializeField] private Button _atkButton;


    private void Start()
    {
        StartBattle();
        _atkButton.onClick.AddListener(Attack);
    }

    private void StartBattle()
    {
        CurrentCombatent = _combatents[Random.Range(0, 2)].Combatant;
        _currentTurn.value = 1;
        UpdateUI();
    }

    private void Attack()
    {
        string mainAttribute = $"{CurrentCombatent.CurrentWeapon.MainAttribute}";
        int attributeScore = (int)CurrentCombatent.Stats.GetType().GetField(mainAttribute).GetValue(CurrentCombatent.Stats);
        int attrModifier = CurrentCombatent.AttributeModifier(attributeScore);

        Debug.Log(CurrentCombatent.CurrentWeapon.Description(attrModifier));

        Unit otherCombatant = _combatents.Find((combatant) => combatant.Combatant != CurrentCombatent);
        otherCombatant.Combatant.HP -= CurrentCombatent.CurrentWeapon.Attack(attrModifier);

        CurrentCombatent = otherCombatant.Combatant;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _currentCombatentName.value = CurrentCombatent.Name;
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
