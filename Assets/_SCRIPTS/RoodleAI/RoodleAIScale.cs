using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoodleAIScale : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter; 

    public float DeltaDownScale;
    private Vector3 downScaleVector;

    private void OnEnable()
    {
        _scoreCounter.NewStageReached += OnReachedNewStage;
    }

    private void OnDisable()
    {
        _scoreCounter.NewStageReached -= OnReachedNewStage;
    }

    private void Start()
    {
        downScaleVector = new Vector3(DeltaDownScale, DeltaDownScale, DeltaDownScale);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            OnReachedNewStage();
        }
    }

    public void OnReachedNewStage()
    {
        if (transform.localScale.x <= 2)
            return;
        transform.localScale -= downScaleVector;
    }
}
