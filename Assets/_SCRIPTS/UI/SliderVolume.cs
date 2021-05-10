using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderVolume : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _value;
    [SerializeField] private AudioSource _audio;

    public void ValueChange()
    {
        DataStorage.SetVolume((int)_slider.value);
        _value.text = ((int)_slider.value).ToString();
        _audio.volume = _slider.value / 100;

        Debug.Log("On change = " + DataStorage.GetVolume());
    }
}
