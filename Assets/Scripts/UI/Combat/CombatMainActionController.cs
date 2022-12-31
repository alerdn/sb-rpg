using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CombatMainActionController : MonoBehaviour
{
    [Header("Animation setup")]
    [SerializeField] private float _swapDuration = .5f;

    [Header("UI setup")]
    [SerializeField] private Button _atkButton;
    [SerializeField] private RectTransform _attackActionsBox;

    private void Start()
    {
        _atkButton.onClick.AddListener(() => Swap(_attackActionsBox));
    }

    private void Swap(RectTransform target)
    {
        RectTransform rect = gameObject.GetComponent<RectTransform>();

        DOTween.To(() => rect.offsetMin.x, (float left) => rect.offsetMin = new Vector2(left, 0), -1028f, _swapDuration);
        DOTween.To(() => rect.offsetMax.x, (float right) => rect.offsetMax = new Vector2(right, 0), -1028f, _swapDuration);
        
        DOTween.To(() => target.offsetMin.x, (float left) => target.offsetMin = new Vector2(left, 0), 0, _swapDuration);
        DOTween.To(() => target.offsetMax.x, (float right) => target.offsetMax = new Vector2(right, 0), 0, _swapDuration);
    }
}
