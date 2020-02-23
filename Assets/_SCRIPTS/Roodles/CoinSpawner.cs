using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject _coinPrefab;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnCoin()
    {
        WaitForSeconds _delay = new WaitForSeconds(2f);

        while (true)
        {
            yield return _delay;
        }
    }
}
