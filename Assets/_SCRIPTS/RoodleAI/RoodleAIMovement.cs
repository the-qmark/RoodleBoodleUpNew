using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoodleAIMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    public float _currentMovementSpeed;
    [SerializeField] private float _increaseMovementSpeed;
    //private float _speedMultiplier;


    [SerializeField] private float _rotateSpeed;
    public float _currentRotateSpeed;
    [SerializeField] private float _increaseRotateSpeed;

    [SerializeField] private Transform _roodle;

    private float[] _xPosition = { 5f, 10, 15f, 20f };
    private float[] _zRotation = { 30, 40, 50, 60, 70, 80 };

    [HideInInspector] public Quaternion newRotate;
    [HideInInspector] public Vector3 newPosition;

    public int _dir;
    private float _step;
    private Rigidbody2D _rigibody;

    private bool isStop;

    public event Action StartMovement;
    public event Action StopMovement;
    public event Action<Quaternion, Vector3, int, float, float> SetNewTransform;

    private void Awake()
    {
        StartMovement += OnStartMovement;
        StopMovement += OnStopMovement;

        StartMovement?.Invoke();
    }

    private void Start()
    {
        _dir = UnityEngine.Random.Range(1, 10) < 5 ? -1 : 1; // -1 влево
        _rigibody = GetComponent<Rigidbody2D>();
        //_speedMultiplier = 1.2f;
        SetNewRotateAndPosition(out newRotate, out newPosition);

    }


    private void Update()
    {
        if (!isStop && transform.position.y > _roodle.position.y + 250)
            StopMovement?.Invoke();
        
        if (isStop && transform.position.y < _roodle.position.y + 201)
            StartMovement?.Invoke();
        
        _step = Time.deltaTime * _currentRotateSpeed;
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotate, _step);

        if (_dir > 0) // вправо
        {
            if (transform.position.x >= newPosition.x)
                SetNewRotateAndPosition(out newRotate, out newPosition);
        }
        else
        {
            if (transform.position.x <= newPosition.x)
                SetNewRotateAndPosition(out newRotate, out newPosition);
        }

    }


    private void FixedUpdate()
    {
        _rigibody.velocity = transform.up * _currentMovementSpeed * Time.fixedDeltaTime;
    }


    private void SetNewRotateAndPosition(out Quaternion newRotate, out Vector3 newPos)
    {
        _dir *= -1;

        int zIndex = UnityEngine.Random.Range(0, _zRotation.Length);
        newRotate = Quaternion.Euler(0, 0, -_zRotation[zIndex] * _dir);

        int xIndex = UnityEngine.Random.Range(0, _xPosition.Length);
        newPos = new Vector3(_xPosition[xIndex] * _dir, 0, 0);

        Debug.Log("DIR = " + _dir);

        SetNewTransform?.Invoke(newRotate, newPos, _dir, _movementSpeed, _rotateSpeed);
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

        //_speedMultiplier += 0.1f;


        if (isStop)
            return;

        _currentMovementSpeed = _movementSpeed;
        _currentRotateSpeed = _rotateSpeed;
    }
}
