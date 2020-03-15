using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private TMP_Text _currretnScoreText;

    public UnityEvent OnNewStageLimit;
    public UnityEvent OnSpawnLimit;

    private int _newStageLimit;
    private int _spawmLimit;

    private float _currentScore;


    void Start()
    {
        _currentScore = 0;
        _currretnScoreText.text = _currentScore.ToString("000000");
        _newStageLimit = 5;
        _spawmLimit = 50;
    }

    void Update()
    {
        _currentScore = _camera.position.y * 0.2f;
        _currretnScoreText.text = _currentScore.ToString("000000");

        if ((int)_currentScore >= _newStageLimit)
        {
            //OnNewStageLimit?.Invoke();
            _newStageLimit += 5;
        }

        if ((int)_currentScore >= _spawmLimit)
        {
            OnSpawnLimit?.Invoke();
            _spawmLimit += 50;
        }
    }

    public void OnGameOver()
    {
        DataStorage.UpdateMaxScore((int)_currentScore);
    }
}
