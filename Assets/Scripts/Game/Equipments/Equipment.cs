using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField] private ScriptableEquipment _equipment;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private EquipmentPopUp _equipPopUp;

    private void Start()
    {
        _equipPopUp.Init(_equipment);
        _equipPopUp.OnCollect += () => Destroy(gameObject);
        _renderer.sprite = _equipment.Sprite;
    }

    private void OnMouseDown()
    {
        _equipPopUp.gameObject.SetActive(true);
    }
}
