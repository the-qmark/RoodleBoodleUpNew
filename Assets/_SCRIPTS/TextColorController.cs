using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextColorController : MonoBehaviour
{
    public ScriptableText scriptableText;

    private TextMeshProUGUI text;

    void Start()
    {
        TryGetComponent<TextMeshProUGUI>(out text);
        text.color = scriptableText.Color;
    }
}
