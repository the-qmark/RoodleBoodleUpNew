using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private RoodleTriggerEnter _roodleTrigger;
    [SerializeField] private Transform _camera;
    [SerializeField] private TMP_Text _currretnScoreText;
    [Space]
    [SerializeField] private int _spawnLimit;
    [SerializeField] private int _newStageLimit;

    private int _spawnLimitIncrease;
    private int _newStageLimitIncrease;

    public UnityAction SpawnLimitReached;
    public UnityAction NewStageReached;

    public int CurrentScore { get; private set; }


    private void OnEnable()
    {
        _roodleTrigger.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _roodleTrigger.GameOver -= OnGameOver;
    }

    void Start()
    {
        CurrentScore = 0;
        _currretnScoreText.text = CurrentScore.ToString("000000");

        _spawnLimitIncrease = _spawnLimit;
        _newStageLimitIncrease = _newStageLimit;
    }

    void Update()
    {
        CurrentScore = (int)(_camera.position.y * 0.2f);
        _currretnScoreText.text = CurrentScore.ToString("000000");

        if (CurrentScore >= _spawnLimit)
        {
            SpawnLimitReached?.Invoke();
            _spawnLimit += _spawnLimitIncrease;
        }

        if (CurrentScore >= _newStageLimit)
        {
            NewStageReached?.Invoke();
            _newStageLimit += _newStageLimitIncrease;
        }
    }

    public void OnGameOver()
    {
        DataStorage.UpdateMaxScore(CurrentScore);
    }
}
