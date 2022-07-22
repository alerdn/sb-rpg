using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerDownHandler
{
    public event Action<ItemSlot> OnItemSelected;

    public ScriptableEquipment Equipment
    {
        get => _equipment;
        set
        {
            _equipment = value;
            if (_equipment != null)
            {
                _sprite.sprite = _equipment.Sprite;
                if (_placeholder != null)
                {
                    _placeholder.gameObject.SetActive(false);
                }
            }
            else
            {
                _sprite.sprite = null;
                if (_placeholder != null)
                {
                    _placeholder.gameObject.SetActive(true);
                }
            }
        }
    }
    // public bool IsEquipped = false;

    [SerializeField] private Image _sprite;
    [SerializeField] private Image _placeholder;
    [SerializeField] private Image _selectionFrame;

    private ScriptableEquipment _equipment;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;

        EventSystem.current.SetSelectedGameObject(gameObject, eventData);
    }

    public void OnSelect(BaseEventData eventData)
    {
        _selectionFrame.gameObject.SetActive(true);
        OnItemSelected?.Invoke(this);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        _selectionFrame.gameObject.SetActive(false);
        OnItemSelected?.Invoke(null);
    }
}
