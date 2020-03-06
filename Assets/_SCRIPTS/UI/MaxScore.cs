using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxScore : MonoBehaviour
{
    private TMP_Text _maxScoreText;

    void Start()
    {
        _maxScoreText = GetComponent<TMP_Text>();
        _maxScoreText.text = DataStorage.GetMaxScore().ToString("000000");
    }
}
