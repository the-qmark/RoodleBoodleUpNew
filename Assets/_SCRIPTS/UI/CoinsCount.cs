using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCount : MonoBehaviour
{
    [SerializeField] TMP_Text _coinCountText;
   
    private void Start()
    {
        UpdateConisCount();
    }

    private void Restart()
    {
        _coinCountText.text = DataStorage.GetCoinsCount().ToString();
    }

    private void UpdateConisCount()
    {
        _coinCountText.text = DataStorage.GetCoinsCount().ToString();
    }
}
