using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOIntUpdate : MonoBehaviour
{
    [SerializeField] private SOInt _soInt;
    [SerializeField] private TMP_Text _text;

    void Start()
    {
        _text.text = _soInt.value.ToString();
    }

    void Update()
    {
        _text.text = _soInt.value.ToString();
    }
}
