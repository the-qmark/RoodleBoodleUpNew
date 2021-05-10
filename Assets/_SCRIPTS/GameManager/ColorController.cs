using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class ColorController : MonoBehaviour
{
    [SerializeField] private Material _mainMaterial;
    [SerializeField] private Material _secondMaterial;
    [SerializeField] private ScoreCounter _scoreCounter;
    [Space]
    public List<Color> Colors = new List<Color>();

    public static UnityAction ColorChanged;

    private float _time;

    private Color _startMainColor;
    private Color _startSecondColor;
    private Color _targetColor;

    private int _currentColorIndex;

    private void OnEnable()
    {
        _scoreCounter.ColorLimitReached += ChangeColor;
    }

    private void OnDisable()
    {
        _scoreCounter.ColorLimitReached -= ChangeColor;
    }


    void Start()
    {
        _currentColorIndex = 0;
        _mainMaterial.color = Colors[_currentColorIndex];

        _secondMaterial.color = InvertColor(_mainMaterial.color);

        _currentColorIndex = 1;
        _time = 0;

        ColorChanged?.Invoke();
    }

    private Color InvertColor(Color clr)
    {
        float r = 1 - clr.r;
        float g = 1 - clr.g;
        float b = 1 - clr.b;

        UnityEngine.Debug.Log("start Color = " + clr + " /// New Color = " + new Color(r, g, b, 1));

        return new Color(r, g, b, 1);
        //return Color.red;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    ChangeColor();
        //}

        //if (c)
        //{
        //    t += Time.deltaTime;
        //    _mainMaterial.color = Color.Lerp(_startColor, _targetColor, t);

        //    if (t > 1)
        //    {
        //        c = false;
        //        t = 0;
        //        if (_currentColorIndex == Colors.Count - 1)
        //        {
        //            _currentColorIndex = 0;
        //        }
        //        else
        //        {
        //            _currentColorIndex++;
        //        }

        //        UnityEngine.Debug.Log("End Coloring");
        //    }
                
        //}

        
        //_mainMaterial.color = Color.Lerp(_mainMaterial.color, Colors[_currentColorIndex], 0.2f);
    }

    private void ChangeColor()
    {
        // _mainMaterial.color = Colors[_currentColorIndex];
        //_mainMaterial.color = Color.Lerp(_mainMaterial.color, Colors[_currentColorIndex], 1f);
        _startMainColor = _mainMaterial.color;
        
        _targetColor = Colors[_currentColorIndex];

        _secondMaterial.color = InvertColor(_targetColor);
        ColorChanged?.Invoke();

        //c = true;

        if (_currentColorIndex == Colors.Count - 1)
        {
            _currentColorIndex = 0;
        }
        else
        {
            _currentColorIndex++;
        }

        StartCoroutine(ColorLerp());



    }


    IEnumerator ColorLerp()
    {
        while (_time < 1)
        {
            _time += Time.deltaTime;
            _mainMaterial.color = Color.Lerp(_startMainColor, _targetColor, _time);
            //_secondMaterial.color = Color.Lerp(_startMainColor, _targetColor, _time);
            yield return new WaitForEndOfFrame();
        }

        //c = false;
        
        _time = 0;

        

        //UnityEngine.Debug.Log("End Coloring");

        yield return new WaitForEndOfFrame();
        
    }

}
