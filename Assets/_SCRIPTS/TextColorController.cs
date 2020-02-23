using System.Collections;
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

        float _r = _scriptableText.Color.r;
        float _g = _scriptableText.Color.g;
        float _b = _scriptableText.Color.b;
        float _a = _text.color.a;

        _text.color = new Color(_r, _g, _b, _a);   
    }
}
