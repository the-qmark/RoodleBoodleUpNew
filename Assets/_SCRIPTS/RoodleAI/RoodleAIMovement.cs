using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoodleAIMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _increaseMovementSpeed;
    [Space]
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _increaseRotateSpeed;
    [Space]
    [SerializeField] private Transform _roodle;
    [Space]
    [SerializeField] private ScoreCounter _scoreCounter;

    private float _currentMovementSpeed;
    private float _currentRotateSpeed;

    private float[] _xPosition = { 5f, 10f, 15f, 20f};
    private float[] _zRotation = { 30, 40, 50, 60, 70, 80 };

    private Quaternion newRotate;
    private Vector3 newPosition;

    private DIRECTION _dir;
    private float _step;
    private Rigidbody2D _rigibody;
    private bool isStop;

    public event Action StartMovement;
    public event Action StopMovement;
    public event Action<Quaternion, Vector3> SetNewTransform;

    private bool _isAutoMove;

    private void Awake()
    {
        StartMovement += OnStartMovement;
        StopMovement += OnStopMovement;
        _currentMovementSpeed = _movementSpeed;
        _currentRotateSpeed = _rotateSpeed;
    }

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
        _dir = UnityEngine.Random.Range(1, 10) < 5 ? DIRECTION.LEFT : DIRECTION.RIGHT;
        _rigibody = GetComponent<Rigidbody2D>();
        SetNewRotateAndPosition(out newRotate, out newPosition);
        StartMovement?.Invoke();
    }


    private void Update()
    {
        if (!isStop && transform.position.y > _roodle.position.y + 260)
            StopMovement?.Invoke();
        
        if (isStop && transform.position.y < _roodle.position.y + 300)
            StartMovement?.Invoke();
        
        _step = Time.deltaTime * _currentRotateSpeed;
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotate, _step);

        if (_dir == DIRECTION.RIGHT) // вправо
        {
            //if (transform.rotation.z > 0)
            //    SetNewTransform?.Invoke(transform.rotation, transform.position);

            if (transform.position.x >= newPosition.x)
                SetNewRotateAndPosition(out newRotate, out newPosition);
        }
        else
        {
            //if (transform.rotation.z < 0)
            //    SetNewTransform?.Invoke(transform.rotation, transform.position);

            if (transform.position.x <= newPosition.x)
                SetNewRotateAndPosition(out newRotate, out newPosition);
            
        }

        transform.Translate(transform.up * _currentMovementSpeed * Time.deltaTime, Space.World);
    }


    private void FixedUpdate()
    {
        //_rigibody.velocity = transform.up * _currentMovementSpeed * Time.deltaTime;
    }

    /// <summary>
    /// Установка нового угла поворота и новой позиции
    /// </summary>
    /// /// <param name="newRotate">Угол поворота</param>
    private void SetNewRotateAndPosition(out Quaternion newRotate, out Vector3 newPos)
    {
        _dir = _dir == DIRECTION.RIGHT ? DIRECTION.LEFT : DIRECTION.RIGHT;

        int zIndex = UnityEngine.Random.Range(0, _zRotation.Length);
        newRotate = Quaternion.Euler(0, 0, -_zRotation[zIndex] * (int)_dir);

        int xIndex = UnityEngine.Random.Range(0, _xPosition.Length);
        newPos = new Vector3(_xPosition[xIndex] * (int)_dir, transform.position.y, transform.position.z);

        SetNewTransform?.Invoke(transform.rotation, transform.position);
    }


    private void OnStartMovement()
    {
        _currentMovementSpeed = _movementSpeed;
        _currentRotateSpeed = _rotateSpeed;
        isStop = false;
    }


    private void OnStopMovement()
    {
        _currentMovementSpeed = 0;
        _currentRotateSpeed = 0;
        isStop = true;
        //transform.Translate(transform.up * _currentMovementSpeed * Time.deltaTime, Space.World);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hexagon"))
        {
            collision.gameObject.SetActive(false);
        }
    }


    public void OnReachedNewStage()
    {
        _movementSpeed += _increaseMovementSpeed;
        _rotateSpeed += _increaseRotateSpeed;

        if (isStop)
            return;

        _currentMovementSpeed = _movementSpeed;
        _currentRotateSpeed = _rotateSpeed;
    }
}
