using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private TMP_Text _sensText;
    [SerializeField] private Slider _sliderSens;
    [SerializeField] private TMP_Text _volText;
    [SerializeField] private Slider _sliderVolume;


    private void OnMouseUpAsButton()
    {
        if (!GameManager.GameIsStart)
        {
            _panel.SetActive(true);

            _sensText.text = DataStorage.GetSens().ToString();
            _sliderSens.value = DataStorage.GetSens();

            


            _volText.text = DataStorage.GetVolume().ToString();
            _sliderVolume.value = DataStorage.GetVolume();

            Debug.Log("On click = " + DataStorage.GetVolume());

            GameManager.GameIsStart = true;
        }
        
    }
}
