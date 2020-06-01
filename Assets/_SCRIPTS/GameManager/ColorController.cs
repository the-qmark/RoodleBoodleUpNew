using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    [SerializeField] private Material _mainMaterial;
    [SerializeField] private Material _secondMaterial;
    [SerializeField] private ScoreCounter _scoreCounter;
    [Space]
    public List<Color> Colors = new List<Color>();

    private int _currentColorIndex;

    private void OnEnable()
    {
        _scoreCounter.ColorLimitReached += ChangeColor;
    }

    private void OnDisable()
    {
        _scoreCounter.ColorLimitReached -= ChangeColor;
    }

    float t;
    bool c;

    Color _startColor;
    Color _targetColor;

    void Start()
    {
        _currentColorIndex = 0;
        _mainMaterial.color = Colors[_currentColorIndex];
        _currentColorIndex = 1;
        t = 0;
        c = false;
        //ChangeColor();
    }

    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeColor();
        }

        if (c)
        {
            t += Time.deltaTime;
            _mainMaterial.color = Color.Lerp(_startColor, _targetColor, t);

            if (t > 1)
            {
                c = false;
                t = 0;
                if (_currentColorIndex == Colors.Count - 1)
                {
                    _currentColorIndex = 0;
                }
                else
                {
                    _currentColorIndex++;
                }

                UnityEngine.Debug.Log("End Coloring");
            }
                
        }

        
        //_mainMaterial.color = Color.Lerp(_mainMaterial.color, Colors[_currentColorIndex], 0.2f);
    }

    private void ChangeColor()
    {
        // _mainMaterial.color = Colors[_currentColorIndex];
        //_mainMaterial.color = Color.Lerp(_mainMaterial.color, Colors[_currentColorIndex], 1f);
        _startColor = _mainMaterial.color;
        _targetColor = Colors[_currentColorIndex]; 
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
        while (t < 1)
        {
            t += Time.deltaTime;
            _mainMaterial.color = Color.Lerp(_startColor, _targetColor, t);
            yield return new WaitForEndOfFrame();
        }

        //c = false;
        
        t = 0;

        

        UnityEngine.Debug.Log("End Coloring");

        yield return new WaitForEndOfFrame();
        
    }

}
