using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoodleController : MonoBehaviour
{
    [SerializeField] private float _speed; // скорость полета
    [SerializeField] private float _increaseSpeed; // на сколько увеличить скорость при достижении нового этапа
    [SerializeField] private float _sensitivity; // чувствительность поворота
    [SerializeField] private Camera cam;


    private float _speedMultiplier;
    private Rigidbody2D _rigibody;
    private Vector3 _currentMousePos;
    private Vector3 _nextMousePos;
    private float _deltaRot;

    //public float SpeedMultiplier { set => _speedMultiplier = value; }


    private void Start()
    {
        _rigibody = GetComponent<Rigidbody2D>();
        _speedMultiplier = 1;
        //cam = Camera.main;
    }


    private void Update()
    {

//#if UNITY_EDITOR
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
        }
//#endif
    }

    private void FixedUpdate()
    {
        _rigibody.velocity = transform.up * _speed * _speedMultiplier * Time.fixedDeltaTime;
    }


    //public void OnGameStarted()
    //{
    //    _currentSpeed = Speed;
    //    _currentSensitivity = Sensitivity;
    //}

    public void OnReachedNewStage()
    {
        //_speed += _increaseSpeed;
        _speedMultiplier += 0.1f;
    }
}
