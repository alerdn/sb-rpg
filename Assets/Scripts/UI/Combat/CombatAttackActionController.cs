using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatAttackActionController : MonoBehaviour
{
    [SerializeField] private Button _primaryWeapon;

    private void Start()
    {
        StartCoroutine(LoadUI());
    }

    private IEnumerator LoadUI()
    {
        yield return new WaitForSeconds(1f);
        _primaryWeapon.GetComponentInChildren<TMP_Text>().text = Battlefield.Instance.CurrentCombatent.CurrentWeapon.Name;
    }
}
