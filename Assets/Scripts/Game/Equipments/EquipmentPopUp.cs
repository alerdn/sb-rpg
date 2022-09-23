using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentPopUp : MonoBehaviour
{
    public event Action OnCollect;

    [SerializeField] private TMP_Text _name;
    [SerializeField] private Button _collectBtn;
    [SerializeField] private Button _closeBtn;

    private ScriptableEquipment _equipment;

    private void Start()
    {
        _collectBtn.onClick.AddListener(Collect);
        _closeBtn.onClick.AddListener(() => gameObject.SetActive(false));
    }

    public void Init(ScriptableEquipment equipment)
    {
        _name.text = equipment.name;
        _equipment = equipment;
    }

    private void Collect()
    {
        HeroManager.Instance.Hero.CollectEquipment(_equipment);
        OnCollect?.Invoke();
    }
}
