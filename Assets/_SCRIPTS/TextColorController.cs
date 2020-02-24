﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextColorController : MonoBehaviour
{
    [SerializeField] private ScriptableText _scriptableText;

    private TMP_Text _text;
    

    void Start()
    {
        TryGetComponent<TMP_Text>(out _text);

        Color clr = _scriptableText.material.color;

        float _r = clr.r;
        float _g = clr.g;
        float _b = clr.b;
        float _a = _text.color.a;

        _text.color = new Color(_r, _g, _b, _a);   
    }
}
