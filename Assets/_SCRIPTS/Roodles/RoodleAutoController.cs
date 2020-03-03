using System.Collections;
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
    [SerializeField] private ParticleSystem _autoMoveEffect;

    private int _index;
    public static bool IsActive;

    public void AddNewData(Quaternion _rotation, Vector3 _position, int dir, float mSpeed, float rSpeed)
    {
        //if (_isActive)
        //    return;

        AutoMoveData moveData = new AutoMoveData(_rotation, _position, dir, mSpeed, rSpeed);
        _autoMoveDataList.Add(moveData);
        //Debug.Log(_autoMoveDataList.Count);
        //Debug.Log("Add new = " + moveData.Rotation + "----" + moveData.Position + "----" + moveData.Dir + "----" + moveData.MovementSpeed + "----" + moveData.RotateSpeed);
    }

    private void Start()
    {
        _rigibody = GetComponent<Rigidbody2D>();
        //_autoMoveData.Add(new AutoMoveData());

    }

    private void OnEnable()
    {
        IsActive = true;

        _index = 0;

        newRotate = _autoMoveDataList[_index].Rotation;
        newPosition = _autoMoveDataList[_index].Position;
        //transform.rotation = newRotate;

        _dir = _autoMoveDataList[_index].Dir;

        _currentMovementSpeed = _autoMoveDataList[_index].MovementSpeed;
        _currentRotateSpeed = _autoMoveDataList[_index].RotateSpeed;

        Debug.Log("OnEnable rotate = " + newRotate);
        Debug.Log("OnEnable position = " + newPosition);
        Debug.Log("OnEnable dir = " + _dir);

        //_currentCount = _autoMoveCount;
        _autoMoveEffect.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _autoMoveEffect.gameObject.SetActive(false);
        _autoMoveDataList.Clear();
        IsActive = false;
    }

    private void Update()
    {
        _step = Time.deltaTime * _currentRotateSpeed;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotate, _step);

        if (_index == _autoMoveDataList.Count - 1)
        {
            if (transform.rotation == newRotate)
                GetNewRotateAndPosition(out newRotate, out newPosition);

            return;
        }

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

        //Debug.Log("auto update");

    }

    private void FixedUpdate()
    {
        _rigibody.velocity = transform.up * _currentMovementSpeed * Time.fixedDeltaTime;
    }

    //private int _autoMoveCount = 4;
    //private float _currentCount = 0;

    private void GetNewRotateAndPosition(out Quaternion newRotate, out Vector3 newPosition)
    {
        // _rigibody.velocity = Vector2.zero;
        //enabled = false;

        //_currentCount--;

        newRotate = Quaternion.identity;
        newPosition = Vector3.zero;

        if (_index == _autoMoveDataList.Count-1)
        {
            _roodleController.enabled = true;
            this.enabled = false;

            
            return;

        }

        _index++;

        newRotate = _autoMoveDataList[_index].Rotation;
        newPosition = _autoMoveDataList[_index].Position;

        _dir = _autoMoveDataList[_index].Dir;

        //try
        //{
            
        //}
        //catch (System.IndexOutOfRangeException)
        //{

        //    Debug.LogError(_index);
        //}
        

        

        //_currentMovementSpeed = _autoMoveDataList[_index].MovementSpeed;
        //_currentRotateSpeed = _autoMoveDataList[_index].RotateSpeed;



        //if (_index == _autoMoveDataList.Count)
        //{

        //    newRotate = Quaternion.identity;
        //    newPosition = Vector3.zero;
        //    return;

        //}

        //Debug.Log("COUNT = " + _autoMoveDataList.Count);
        //Debug.Log("INDEX = " + _index);




    }


}
