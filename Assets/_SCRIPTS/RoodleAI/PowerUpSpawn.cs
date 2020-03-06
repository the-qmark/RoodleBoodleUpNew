using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    [SerializeField] private AutoMove _autoMovePref;
    [SerializeField] private RoodleAutoController _roodleAutoController;
    [SerializeField] private RoodleController _roodleController;

    private RoodleAIMovement _roodleAIMovement;

    private bool _autoMoveIsSpawn = false;
    private int _autoMoveCount = 3;
    private float _currentCount = 0;
    private float _chanceForAutoMove;

    private void Start()
    {
        _roodleAIMovement = GetComponent<RoodleAIMovement>();
        _roodleAIMovement.SetNewTransform += SpawnAutoMove;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            _autoMoveIsSpawn = false;
        }
    }


    private void SpawnAutoMove(Quaternion _rotate, Vector3 _position, DIRECTION _direction, float _moveSpeed, float _rotateSpeed)
    {
        if (_autoMoveIsSpawn)
        {
            _roodleAutoController.AddNewData(_rotate, _position, _direction, _moveSpeed, _rotateSpeed);
            _currentCount--;

            if (_currentCount <= 0)
                _autoMoveIsSpawn = false;
        }

        if (AutoMove.IsActive || RoodleAutoController.IsActive)
            return;

        _chanceForAutoMove = Random.Range(0, 20);

        if (_chanceForAutoMove > 17 && !_autoMoveIsSpawn)
        {
            Instantiate(_autoMovePref, transform.position, transform.rotation);
            _roodleAutoController.AddNewData(_rotate, _position, _direction, _moveSpeed, _rotateSpeed);
            _currentCount = _autoMoveCount;
            _autoMoveIsSpawn = true;
        }
    }
}
