using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    private IEnumerator _spawnCoinRoutine;
    private RoodleAIMovement _roodleAIMovement;
    private WaitForSeconds _delay = new WaitForSeconds(2f);
    private float _chanceForCoin;


    private void Start()
    {
        _roodleAIMovement = GetComponent<RoodleAIMovement>();

        _roodleAIMovement.StartMovement += StartCoinSpawn;
        _roodleAIMovement.StopMovement += StopCoinSpawn;

        _spawnCoinRoutine = SpawnCoin();
    }


    public void StartCoinSpawn()
    {
        StartCoroutine(_spawnCoinRoutine);
        Debug.Log("coin");
    }


    public void StopCoinSpawn()
    {
        StopCoroutine(_spawnCoinRoutine);
    }


    private IEnumerator SpawnCoin()
    {
        while (true)
        {
            _chanceForCoin = Random.Range(0, 10);

            if (_chanceForCoin >= 0)
                Instantiate(_coinPrefab, transform.position, Quaternion.identity);

            yield return _delay;
        }
    }
}
