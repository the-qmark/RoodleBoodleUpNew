using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpawner : MonoBehaviour
{
    [SerializeField] private CoinSpawner _coinSpawner;
    [SerializeField] private PowerUpSpawn _powerUpSpawner;

    private int _chance;

    public void SpawnStuff()
    {
        _chance = Random.Range(0, 20);

        if (_chance > 17)
        {
            // powerup
        }
        else if (_chance >10)
        {
            _coinSpawner.SpawnCoin();
        }
    }
}
