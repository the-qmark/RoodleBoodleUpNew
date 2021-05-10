using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderSensitivity : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _value; 

    public void ValueChange()
    {
        DataStorage.SetSens((int)_slider.value);
        _value.text = ((int)_slider.value).ToString();
    }

}
