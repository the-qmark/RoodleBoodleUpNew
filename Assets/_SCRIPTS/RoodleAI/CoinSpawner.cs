using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    private int _chance;

    public void SpawnCoin()
    {
        _chance = Random.Range(0, 20);

        if (_chance > 5)
            Instantiate(_coinPrefab, transform.position, Quaternion.identity);
    }

}
