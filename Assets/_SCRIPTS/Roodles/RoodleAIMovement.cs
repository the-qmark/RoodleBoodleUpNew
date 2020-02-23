using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        //dir = Random.Range(1, 10);
        _dir = Random.Range(1, 10) < 5 ? -1 : 1; // -1 влево
        _rigibody = GetComponent<Rigidbody2D>();
        SetNewRotateAndPosition(out _newRotate, out _newPosition);
        StartMovement();
    }


    private void Update()
    {
        if (transform.position.y > _roodle.position.y + 250)
        {
            isStop = true;
            StopMovement();
        }

        if (isStop && transform.position.y > _roodle.position.y + 200)
            return;
        else
        {
            isStop = false;
            StartMovement();
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

        int zIndex = Random.Range(0, _zRotation.Length);
        _newRotate = Quaternion.Euler(0, 0, -_zRotation[zIndex] * _dir);

        int xIndex = Random.Range(0, _xPosition.Length);
        _newPos = new Vector3(_xPosition[xIndex] * _dir, 0, 0);

        
    }

    private void StopMovement()
    {
        _currentMovementSpeed = 0;
        _currentRotateSpeed = 0;
    }

    private void StartMovement()
    {
        _currentMovementSpeed = _movementSpeed;
        _currentRotateSpeed = _rotateSpeed;
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
        StartMovement();
    }
}
