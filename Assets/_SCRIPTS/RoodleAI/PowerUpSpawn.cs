using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    [SerializeField] private AutoMove _autoMovePref;
    [SerializeField] private RoodleAutoController _roodleAutoController;

    private IEnumerator _spawnPowerUpRoutine;
    private RoodleAIMovement _roodleAIMovement;


    private void Start()
    {
        //_roodleAIMovement = GetComponent<RoodleAIMovement>();

        //_roodleAIMovement.StartMovement += StartPowerUpSpawn;
        //_roodleAIMovement.StopMovement += StopPowerUpSpawn;

        //_spawnPowerUpRoutine = PowerSpawn();

        //a = true;


        _roodleAIMovement.SetNewTransform += SpawnAutoMove;
    }


    private void StartPowerUpSpawn()
    {
        StartCoroutine(_spawnPowerUpRoutine);
    }

    private void StopPowerUpSpawn()
    {
        StopCoroutine(_spawnPowerUpRoutine);
    }

    private bool a;

    //private IEnumerator PowerSpawn()
    //{
    //    //WaitForSeconds _delay = new WaitForSeconds(1f);

    //    //yield return _delay;

    //    //float _chance;

    //    //while (true)
    //    //{
    //    //    _chance = Random.Range(0, 20);

    //    //    if (_chance > 0 && a)
    //    //    {
    //    //        Instantiate(_autoMovePref, transform.position, Quaternion.identity);
    //    //        _roodleAuto.AddNewData(_roodleAIMovement.newRotate, _roodleAIMovement.newPosition, _roodleAIMovement._dir, 
    //    //            _roodleAIMovement._currentMovementSpeed, _roodleAIMovement._currentRotateSpeed);


    //    //        Debug.Log(_roodleAIMovement._currentMovementSpeed);
    //    //        _roodleAIMovement.isSpawnAuto = true;

    //    //        a = false;

    //    //        //_auto.SetDataForAutoMove(_roodleAIMovement.newRotate, _roodleAIMovement.newPosition);

    //    //    }

    //    //    yield return _delay;
    //    //}
    //}

    private bool _autoMoveIsSpawn = false;
    private int _autoMoveCount = 4;
    private float _currentCount = 0;

    private void SpawnAutoMove()
    {
        float _chance = Random.Range(0, 20);
        

        if (_chance > 17 && !_autoMoveIsSpawn)
        {

            Instantiate(_autoMovePref, transform.position, Quaternion.identity);

            _roodleAutoController.AddNewData(_roodleAIMovement.newRotate, _roodleAIMovement.newPosition, _roodleAIMovement._dir,
                _roodleAIMovement._currentMovementSpeed, _roodleAIMovement._currentRotateSpeed);

            _currentCount = _autoMoveCount;

            _autoMoveIsSpawn = true;
        }
        else
        if (_autoMoveIsSpawn)
        {
            _currentCount--;

            _roodleAutoController.AddNewData(_roodleAIMovement.newRotate, _roodleAIMovement.newPosition, _roodleAIMovement._dir,
                _roodleAIMovement._currentMovementSpeed, _roodleAIMovement._currentRotateSpeed);

            if (_currentCount == 0)
                _autoMoveIsSpawn = false;
        }
       
    }
}
