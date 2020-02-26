using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoodleAutoController : MonoBehaviour
{
    [SerializeField] private List<AutoMoveData> _autoMoveData = new List<AutoMoveData>();

    private int _dir;
    private float _step;
    private Rigidbody2D _rigibody;

    private float _currentMovementSpeed;
    private float _currentRotateSpeed;
    private Quaternion newRotate;
    private Vector3 newPosition;

    private int _index;

    public void AddNewData(Quaternion _rotation, Vector3 _position, int dir, float mSpeed, float rSpeed)
    {
        AutoMoveData moveData = new AutoMoveData(_rotation, _position, dir, mSpeed, rSpeed);
        _autoMoveData.Add(moveData);
        //Debug.Log("Add new = " + moveData.Rotation + "----" + moveData.Position + "----" + moveData.Dir + "----" + moveData.MovementSpeed + "----" + moveData.RotateSpeed);
    }

    private void Start()
    {
        _rigibody = GetComponent<Rigidbody2D>();
        //_autoMoveData.Add(new AutoMoveData());

    }

    private void OnEnable()
    {
        _index = 0;

        newRotate = _autoMoveData[_index].Rotation;
        newPosition = _autoMoveData[_index].Position;

        _dir = _autoMoveData[_index].Dir;

        _currentMovementSpeed = _autoMoveData[_index].MovementSpeed;
        _currentRotateSpeed = _autoMoveData[_index].RotateSpeed;

        //Debug.Log("OnEnable speed = " + _currentMovementSpeed);
    }

    private void Update()
    {
        _step = Time.deltaTime * _currentRotateSpeed;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotate, _step);

        if (_dir > 0) // вправо
        {
            if (transform.position.x >= newPosition.x)
            {
                if (_index >= _autoMoveData.Count-1)
                    return;
                GetNewRotateAndPosition(out newRotate, out newPosition);
            }
        }
        else
        {
            if (transform.position.x <= newPosition.x)
            {
                if (_index >= _autoMoveData.Count-1)
                    return;
                GetNewRotateAndPosition(out newRotate, out newPosition);
            }
        }

    }

    private void FixedUpdate()
    {
        _rigibody.velocity = transform.up * _currentMovementSpeed * Time.fixedDeltaTime;
        
    }

    private void GetNewRotateAndPosition(out Quaternion newRotate, out Vector3 newPosition)
    {
        _index++;

        newRotate = _autoMoveData[_index].Rotation;
        newPosition = _autoMoveData[_index].Position;

        _currentMovementSpeed = _autoMoveData[_index].MovementSpeed;
        _currentRotateSpeed = _autoMoveData[_index].RotateSpeed;

        Debug.Log("NEW");
    }


}
