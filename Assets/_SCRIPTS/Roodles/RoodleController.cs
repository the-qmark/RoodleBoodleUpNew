using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoodleController : MonoBehaviour
{
    [SerializeField] private float _speed; // скорость полета
    [SerializeField] private float _increaseSpeed; // на сколько увеличить скорость при достижении нового этапа
    [Space][SerializeField] private float _sensitivity; // чувствительность поворота
    [Space][SerializeField] private Camera cam;
    [Space]
    [SerializeField] private ScoreCounter _scoreCounter;

    //private Rigidbody2D _rigibody;
    private Vector3 _currentMousePos;
    private Vector3 _nextMousePos;
    private float _deltaRot;

    public RoodleData ActiveRoodle;

    public float Speed { get => _speed; }


    private void Awake()
    {
        //_rigibody = GetComponent<Rigidbody2D>();
    }


    private void OnEnable()
    {
        _currentMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        ActiveRoodle.FlyEffect.SetActive(true);
        _scoreCounter.NewStageReached += OnReachedNewStage;
        _sensitivity = DataStorage.GetSens();
    }


    private void OnDisable()
    {
        //_rigibody.velocity = Vector2.zero;
        _scoreCounter.NewStageReached -= OnReachedNewStage;

    }


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _currentMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            _nextMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            _deltaRot = _currentMousePos.x - _nextMousePos.x;
            _currentMousePos = _nextMousePos;
            transform.Rotate(Vector3.forward, _deltaRot * _sensitivity * Time.deltaTime);
            _deltaRot = 0;
        }

        transform.Translate(transform.up * _speed * Time.deltaTime, Space.World);
    }
    

    public void OnReachedNewStage()
    {
        _speed += _increaseSpeed;
    }
}
