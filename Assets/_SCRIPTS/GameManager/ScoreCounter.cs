using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private TMP_Text _currretnScoreText;

    [SerializeField] private int _newStageLimit;
    [SerializeField] private int _coinLimit;
    [SerializeField] private int _letterLimit;

    private int _newStageLimitIncrease;
    private int _coinLimitIncrease;
    private int _letterLimitIncrease;

    public UnityEvent OnNewStageLimit;
    public UnityEvent OnCoinLimit;
    public UnityEvent OnLetterLimit;

    
    private float _currentScore;


    void Start()
    {
        _currentScore = 0;
        _currretnScoreText.text = _currentScore.ToString("000000");

        _newStageLimitIncrease = _newStageLimit;
        _coinLimitIncrease = _coinLimit;
        _letterLimitIncrease = _letterLimit;
    }

    void Update()
    {
        _currentScore = _camera.position.y * 0.2f;
        _currretnScoreText.text = _currentScore.ToString("000000");

        if ((int)_currentScore >= _newStageLimit)
        {
            OnNewStageLimit?.Invoke();
            _newStageLimit += _newStageLimitIncrease;
        }

        if ((int)_currentScore >= _coinLimit)
        {
            OnCoinLimit?.Invoke();
            _coinLimit += _coinLimitIncrease;
        }

        if ((int)_currentScore >= _letterLimit)
        {
            OnLetterLimit?.Invoke();
            _letterLimit += _letterLimitIncrease;
        }
    }

    public void OnGameOver()
    {
        DataStorage.UpdateMaxScore((int)_currentScore);
    }
}
