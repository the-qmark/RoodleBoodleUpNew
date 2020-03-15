using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoodleAutoController : MonoBehaviour
{
    [SerializeField] private RoodleController _roodleController;
    [SerializeField] private ParticleSystem _autoMoveEffect;

    private List<AutoMoveData> _autoMoveDataList = new List<AutoMoveData>();
    private DIRECTION _dir;
    [SerializeField] private float _currentMovementSpeed;
    [SerializeField] private float _currentRotateSpeed;
    [SerializeField] private Quaternion newRotate;
    [SerializeField] private Vector3 newPosition;

    private float _step;
    private Rigidbody2D _rigibody;

    private int _index;
    public static bool IsActive;


    public void AddNewData(Quaternion _rotation, Vector3 _position, DIRECTION dir, float mSpeed, float rSpeed)
    {
        AutoMoveData moveData = new AutoMoveData(_rotation, _position, dir, mSpeed, rSpeed);
        _autoMoveDataList.Add(moveData);
    }


    private void Start()
    {
        _rigibody = GetComponent<Rigidbody2D>();
    }


    private void OnEnable()
    {
        IsActive = true;

        _index = 0;

        newRotate = _autoMoveDataList[_index].Rotation;
        newPosition = _autoMoveDataList[_index].Position;

        _dir = _autoMoveDataList[_index].Dir;

        _currentMovementSpeed = _autoMoveDataList[_index].MovementSpeed;
        _currentRotateSpeed = _autoMoveDataList[_index].RotateSpeed;

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

        if (_dir == DIRECTION.RIGHT)
        {
            if (transform.position.x >= newPosition.x)
            {
                GetNewRotateAndPosition(out newRotate, out newPosition);
            }
        }
        else
        {
            if (transform.position.x <= newPosition.x)
            {
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
        newRotate = Quaternion.identity;
        newPosition = Vector3.zero;

        if (_index == _autoMoveDataList.Count - 1)
        {
            _roodleController.enabled = true;
            this.enabled = false;

            return;
        }

        _index++;

        newRotate = _autoMoveDataList[_index].Rotation;
        newPosition = _autoMoveDataList[_index].Position;

        _dir = _autoMoveDataList[_index].Dir;
    }

    public void GameOver()
    {
        Debug.Log($"Rotation : {transform.rotation.eulerAngles} | newRotate Rotation: {newRotate.eulerAngles}");
    }

}
