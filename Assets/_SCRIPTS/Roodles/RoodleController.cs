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

    private Rigidbody2D _rigibody;
    private Vector3 _currentMousePos;
    private Vector3 _nextMousePos;
    private float _deltaRot;

    public RoodleData ActiveRoodle;



    private void Start()
    {
        _rigibody = GetComponent<Rigidbody2D>();
    }


    private void OnEnable()
    {
        _currentMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        ActiveRoodle.RoodleFlyEffect.SetActive(true);
    }

    private void OnDisable()
    {
        _rigibody.velocity = Vector2.zero;
        
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
            _deltaRot = 0;
        }
//#endif
    }
    

    private void FixedUpdate()
    {
        _rigibody.velocity = transform.up * _speed * Time.fixedDeltaTime;
    }


    public void OnReachedNewStage()
    {
        _speed += _increaseSpeed;
    }
}
