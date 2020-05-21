using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BubbleMove : MonoBehaviour
{
    [SerializeField] private AutoMoveForce _moveForce;
    [SerializeField] private Bubble _bubble;
    [SerializeField] RoodleController _roodleController;
    [SerializeField] CircleCollider2D _collider;
    [SerializeField] private float _sideSpeed;
    [SerializeField] private int _bubbleJumpCount = 6;

    private int _currentBubbleJumpCount;
    private DIRECTION _dir; // 0 = left
    private Vector2 _vector = Vector2.up;

    private float _borderMin = 5;
    private float _borderMax = 30;
    private float _pos;

    private float _upSpeed;
    private float _step;

    public UnityAction AutoMoveStart;
    public UnityAction AutoMoveEnd;

    


    private void OnEnable()
    {
        //_bubble.gameObject.SetActive(true);
        _moveForce.ScaleUp();

        _dir = transform.position.x > 0 ? DIRECTION.LEFT : DIRECTION.RIGHT;
        _upSpeed = _roodleController.Speed + 40;
        _currentBubbleJumpCount = 0;
        GetComponent<CircleCollider2D>().enabled = false;
        GetNewPosition();
        _collider.enabled = true;

        AutoMoveStart?.Invoke();
    }


    private void OnDisable()
    {
        //AutoMoveEnd?.Invoke();
        _collider.enabled = false;
    }


    private void Update()
    {
        if (_currentBubbleJumpCount == _bubbleJumpCount)
        {
            _step = _upSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, _vector, _step);

            if (Vector3.Distance(transform.position, _vector) < 0.01f)
            {
                //_bubble.gameObject.SetActive(false);
                GetComponent<CircleCollider2D>().enabled = true;
                //_roodleController.enabled = true;
                this.enabled = false;
                //_moveForce.ScaleDown();
            }
        }
        else
        {
            transform.Translate(_vector * Time.deltaTime, Space.World);

            if (_dir == DIRECTION.RIGHT)
            {
                if (transform.position.x >= _pos)
                {
                    _dir = DIRECTION.LEFT;
                    GetNewPosition();
                }
            }
            else
            {
                if (transform.position.x <= _pos)
                {
                    _dir = DIRECTION.RIGHT;
                    GetNewPosition();
                }

            }
        }           
    }


    private void GetNewPosition()
    {
        //_pos = Random.Range(_borderMin, _borderMax) * (int)_dir;
        _pos = 5 * (int)_dir;
        _vector = new Vector2(_pos * _sideSpeed, 1 * _upSpeed);

        _currentBubbleJumpCount++;

        if (_currentBubbleJumpCount == _bubbleJumpCount)
        {
            _vector = new Vector2(0, transform.position.y + 150);
            _upSpeed = _roodleController.Speed + 80;
            _moveForce.ScaleDown();
            //Debug.Log("50");
            AutoMoveEnd?.Invoke();
            _roodleController.enabled = true;
            //_vector = new Vector2(0, transform.position.y);
            _bubble.ScaleUp = true;
        }
    }

}
