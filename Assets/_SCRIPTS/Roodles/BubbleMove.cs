using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMove : MonoBehaviour
{
    [SerializeField] private Bubble _bubble;
    [SerializeField] private float _sideSpeed;

    private int _bubbleJumpCount = 6;
    private int _currentBubbleJumpCount;
    private DIRECTION _dir; // 0 = left
    private Vector2 _vector = Vector2.up;

    private float _borderMin = 5;
    private float _borderMax = 8;
    private float _pos;

    [SerializeField] private RoodleController _roodleController;
    private float _upSpeed;
    private float _step;

    private void Start()
    {
        //_roodleController = GetComponent<RoodleController>();
        //Debug.Log("bbbb");
    }

    private void OnEnable()
    {
        _bubble.gameObject.SetActive(true);
        _dir = transform.position.x > 0 ? DIRECTION.LEFT : DIRECTION.RIGHT;
        _upSpeed = _roodleController.Speed + 40;
        _currentBubbleJumpCount = 0;
        GetComponent<CircleCollider2D>().enabled = false;
        GetNewPosition();
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
                _roodleController.enabled = true;
                this.enabled = false;
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
        _pos = Random.Range(_borderMin, _borderMax) * (int)_dir;
        _vector = new Vector2(_pos * _sideSpeed, 1 * _upSpeed);
        _currentBubbleJumpCount++;
        if (_currentBubbleJumpCount == _bubbleJumpCount)
        {
            _vector = new Vector2(0, transform.position.y + 50);
            _bubble.ScaleUp = true;
        }
    }

}
