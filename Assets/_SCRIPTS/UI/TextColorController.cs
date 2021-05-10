using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextColorController : MonoBehaviour
{
    [SerializeField] private ScriptableText _scriptableText;
    //[SerializeField] private ColorController colorController;

    private TMP_Text _text;


    private void OnEnable()
    {
        ColorController.ColorChanged += ChangeColor;
        //colorController.ColorChanged += ChangeColor;
    }

    private void OnDisable()
    {
        ColorController.ColorChanged -= ChangeColor;
    }

    void Start()
    {
        ChangeColor();
    }


    private void ChangeColor()
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
