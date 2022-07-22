using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerDownHandler
{
    [SerializeField] private Image selectionFrame;

    public void OnDeselect(BaseEventData eventData)
    {
        Debug.Log("Deselect");
        selectionFrame.gameObject.SetActive(false);
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("Select");
        selectionFrame.gameObject.SetActive(true);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;

        // Selection tracking
        EventSystem.current.SetSelectedGameObject(gameObject, eventData);
    }
}
