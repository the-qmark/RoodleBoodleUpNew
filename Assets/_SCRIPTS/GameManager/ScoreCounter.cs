using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private TMP_Text _currretnScoreText;

    public UnityEvent CreatedNewStage;
    private int _newStageLimit;

    private float _currentScore;


    void Start()
    {
        _currentScore = 0;
        _currretnScoreText.text = _currentScore.ToString("000000");
        _newStageLimit = 10;
    }

    void Update()
    {
        _currentScore = _camera.position.y * 0.2f;
        _currretnScoreText.text = _currentScore.ToString("000000");

        if ((int)_currentScore >= _newStageLimit)
        {
            CreatedNewStage?.Invoke();
            _newStageLimit += 10;
        }
            
    }


    //private void NexStage()
    //{

    //}
}
