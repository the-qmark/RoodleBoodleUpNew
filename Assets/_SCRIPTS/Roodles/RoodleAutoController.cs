using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoodleAutoController : MonoBehaviour
{
    [SerializeField] private List<AutoMoveData> _autoMoveDataList = new List<AutoMoveData>();

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
        _autoMoveDataList.Add(moveData);
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

        newRotate = _autoMoveDataList[_index].Rotation;
        newPosition = _autoMoveDataList[_index].Position;
        transform.rotation = newRotate;

        _dir = _autoMoveDataList[_index].Dir;

        _currentMovementSpeed = _autoMoveDataList[_index].MovementSpeed;
        _currentRotateSpeed = _autoMoveDataList[_index].RotateSpeed;

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
                //if (_index >= _autoMoveDataList.Count-1)
                //    return;
                GetNewRotateAndPosition(out newRotate, out newPosition);
            }
        }
        else
        {
            if (transform.position.x <= newPosition.x)
            {
                //if (_index >= _autoMoveDataList.Count-1)
                //    return;
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
        // _rigibody.velocity = Vector2.zero;
        //enabled = false;

        

        _index++;

        Debug.Log("COUNT = " + _autoMoveDataList.Count);
        Debug.Log("INDEX = " + _index);

        newRotate = _autoMoveDataList[_index].Rotation;
        newPosition = _autoMoveDataList[_index].Position;

        _dir = _autoMoveDataList[_index].Dir;

        _currentMovementSpeed = _autoMoveDataList[_index].MovementSpeed;
        _currentRotateSpeed = _autoMoveDataList[_index].RotateSpeed;

        
    }


}
