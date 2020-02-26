using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] Coin _coinPrefab;
    private IEnumerator _spawnCoinRoutine;
    private RoodleAIMovement _roodleAIMovement;


    private void Start()
    {
        _roodleAIMovement = GetComponent<RoodleAIMovement>();

        _roodleAIMovement.StartMovement += StartCoinSpawn;
        _roodleAIMovement.StopMovement += StopCoinSpawn;
    }

    public void StartCoinSpawn()
    {
        if (_spawnCoinRoutine == null)
            _spawnCoinRoutine = SpawnCoin();

        StartCoroutine(_spawnCoinRoutine);
        Debug.Log("StartCour");
    }


    public void StopCoinSpawn()
    {
        StopCoroutine(_spawnCoinRoutine);
        //StopCoroutine()
        //StopAllCoroutines();
        Debug.Log("StopCour");
    }


    private IEnumerator SpawnCoin()
    {
        WaitForSeconds _delay = new WaitForSeconds(2f);

        float _chance;

        Debug.Log("Cour + " + gameObject.name);

        while (true)
        {
            _chance = Random.Range(0, 10);

            if (_chance >= 5)
                Instantiate(_coinPrefab, transform.position, Quaternion.identity);

            Debug.Log("COIN + " + Time.time);
            
            yield return _delay;
        }
    }
}
