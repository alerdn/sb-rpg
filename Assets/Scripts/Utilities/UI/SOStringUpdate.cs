using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOStringUpdate : MonoBehaviour
{
    [SerializeField] private SOString _soString;
    [SerializeField] private TMP_Text _text;

    void Start()
    {
        _text.text = _soString.value.ToString();
    }

    void Update()
    {
        _text.text = _soString.value.ToString();
    }
}
