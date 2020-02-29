﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoodleAutoController : MonoBehaviour
{
    [SerializeField] private List<AutoMoveData> _autoMoveDataList = new List<AutoMoveData>();

    [SerializeField] private int _dir;
    private float _step;
    private Rigidbody2D _rigibody;

    [SerializeField] private float _currentMovementSpeed;
    [SerializeField] private float _currentRotateSpeed;
    [SerializeField] private Quaternion newRotate;
    [SerializeField] private Vector3 newPosition;

    [SerializeField] private RoodleController _roodleController;

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
        //transform.rotation = newRotate;

        _dir = _autoMoveDataList[_index].Dir;

        _currentMovementSpeed = _autoMoveDataList[_index].MovementSpeed;
        _currentRotateSpeed = _autoMoveDataList[_index].RotateSpeed;

        //Debug.Log("OnEnable speed = " + _currentMovementSpeed);
        _currentCount = _autoMoveCount;
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

        Debug.Log("auto update");

    }

    private void FixedUpdate()
    {
        _rigibody.velocity = transform.up * _currentMovementSpeed * Time.fixedDeltaTime;
        
    }

    private int _autoMoveCount = 4;
    private float _currentCount = 0;

    private void GetNewRotateAndPosition(out Quaternion newRotate, out Vector3 newPosition)
    {
        // _rigibody.velocity = Vector2.zero;
        //enabled = false;

        _currentCount--;

        if (_currentCount < 1)
        {
            _roodleController.enabled = true;
            this.enabled = false;

            newRotate = Quaternion.identity;
            newPosition = Vector3.zero;
            return;

        }




        _index++;

        //if (_index == _autoMoveDataList.Count)
        //{

        //    newRotate = Quaternion.identity;
        //    newPosition = Vector3.zero;
        //    return;

        //}

        //Debug.Log("COUNT = " + _autoMoveDataList.Count);
        //Debug.Log("INDEX = " + _index);

        newRotate = _autoMoveDataList[_index].Rotation;
        newPosition = _autoMoveDataList[_index].Position;

        _dir = _autoMoveDataList[_index].Dir;

        _currentMovementSpeed = _autoMoveDataList[_index].MovementSpeed;
        _currentRotateSpeed = _autoMoveDataList[_index].RotateSpeed;

        
    }


}