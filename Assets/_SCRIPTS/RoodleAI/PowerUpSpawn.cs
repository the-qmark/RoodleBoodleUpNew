using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    [SerializeField] private AutoMove _autoMovePref;

    private IEnumerator _spawnPowerUpRoutine;
    private RoodleAIMovement _roodleAIMovement;


    private void Start()
    {
        _roodleAIMovement = GetComponent<RoodleAIMovement>();

        _roodleAIMovement.StartMovement += StartPowerUpSpawn;
        _roodleAIMovement.StopMovement += StopPowerUpSpawn;

        _spawnPowerUpRoutine = PowerSpawn();

    }


    private void StartPowerUpSpawn()
    {
        StartCoroutine(_spawnPowerUpRoutine);
    }

    private void StopPowerUpSpawn()
    {
        StopCoroutine(_spawnPowerUpRoutine);
    }

    private IEnumerator PowerSpawn()
    {
        WaitForSeconds _delay = new WaitForSeconds(10f);

        float _chance;

        while (true)
        {
            _chance = Random.Range(0, 20);

            if (_chance > 17)
            {
                AutoMove _auto = Instantiate(_autoMovePref, transform.position, Quaternion.identity);

                _auto.SetDataForAutoMove(_roodleAIMovement._newRotate, _roodleAIMovement._newPosition);

            }

            yield return _delay;
        }
    }
}
