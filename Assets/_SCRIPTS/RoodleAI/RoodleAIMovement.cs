using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoodleAIMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    private float _currentMovementSpeed;
    [SerializeField] private float _increaseMovementSpeed;

    [SerializeField] private float _rotateSpeed;
    private float _currentRotateSpeed;
    [SerializeField] private float _increaseRotateSpeed;

    [SerializeField] private Transform _roodle;

    private float[] _xPosition = { 5f, 10, 15f, 20f };
    private float[] _zRotation = { 30, 40, 50, 60, 70, 80 };

    private Quaternion _newRotate;
    private Vector3 _newPosition;

    private int _dir;
    private float _step;
    private Rigidbody2D _rigibody;

    private bool isStop;

    //private CoinSpawner _coinSpawner;
    public event Action StartMovement;
    public event Action StopMovement;


    private void Start()
    {
        //dir = Random.Range(1, 10);
        //_coinSpawner = GetComponent<CoinSpawner>();
        _dir = UnityEngine.Random.Range(1, 10) < 5 ? -1 : 1; // -1 влево
        _rigibody = GetComponent<Rigidbody2D>();
        SetNewRotateAndPosition(out _newRotate, out _newPosition);

        StartMovement += OnStartMovement;
        StopMovement += OnStopMovement;

        StartMovement?.Invoke();

        //OnStartMovement();
    }


    private void Update()
    {
        if (!isStop && transform.position.y > _roodle.position.y + 250)
        {
            //isStop = true;
            StopMovement?.Invoke();
            //OnStopMovement();
        }
        
        if (isStop && transform.position.y < _roodle.position.y + 201)
        {
            //isStop = false;
            StartMovement?.Invoke();
            //OnStartMovement();
        }
            
        
        _step = Time.deltaTime * _currentRotateSpeed;
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _newRotate, _step);

        if (_dir > 0) // вправо
        {
            if (transform.position.x >= _newPosition.x)
            {
                SetNewRotateAndPosition(out _newRotate, out _newPosition);
            }
        }
        else
        {
            if (transform.position.x <= _newPosition.x)
            {
                SetNewRotateAndPosition(out _newRotate, out _newPosition);
            }
        }

    }


    private void FixedUpdate()
    {
        _rigibody.velocity = transform.up * _currentMovementSpeed * Time.fixedDeltaTime;
    }


    private void SetNewRotateAndPosition(out Quaternion _newRotate, out Vector3 _newPos)
    {
        _dir *= -1;

        int zIndex = UnityEngine.Random.Range(0, _zRotation.Length);
        _newRotate = Quaternion.Euler(0, 0, -_zRotation[zIndex] * _dir);

        int xIndex = UnityEngine.Random.Range(0, _xPosition.Length);
        _newPos = new Vector3(_xPosition[xIndex] * _dir, 0, 0);  
    }


    private void OnStartMovement()
    {
        _currentMovementSpeed = _movementSpeed;
        _currentRotateSpeed = _rotateSpeed;
        isStop = false;
        //_coinSpawner.StartCoinSpawn();
    }


    private void OnStopMovement()
    {
        _currentMovementSpeed = 0;
        _currentRotateSpeed = 0;
        isStop = true;
        //_coinSpawner.StopCoinSpawn();
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
