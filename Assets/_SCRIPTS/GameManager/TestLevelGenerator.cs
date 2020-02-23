using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform _roodle;
    [SerializeField] private GameObject _mainLine;
    [SerializeField] private int _counOfLine;
    private float DeltaY = 16.94f;
    private float currentY;

    private GameObject[] _lines;
    private int _bottomLineIndex, _upLineIndex;

    
    private void Start()
    {
        _lines = new GameObject[_counOfLine];

        currentY = 144.92f + DeltaY;
        for (int i = 0; i < _counOfLine; i++)
        {
            _lines[i] = Instantiate(_mainLine, new Vector3(0, currentY, 0), Quaternion.identity);
            currentY += DeltaY;
        }

        _bottomLineIndex = 0;
        _upLineIndex = _counOfLine - 1;
    }

    private void Update()
    {
        if (_roodle.position.y >= _lines[_bottomLineIndex].transform.position.y + 200)
        {
            _lines[_bottomLineIndex].GetComponent<MainLine>().SetAcitiveTrue();
            _lines[_bottomLineIndex].transform.position = new Vector3(0, _lines[_upLineIndex].transform.position.y + DeltaY, 0);

            if (_upLineIndex == _counOfLine - 1)
                _upLineIndex = 0;
            else
                _upLineIndex++;

            if (_bottomLineIndex == _counOfLine - 1)
                _bottomLineIndex = 0;
            else
                _bottomLineIndex++;
        }
    }
}
