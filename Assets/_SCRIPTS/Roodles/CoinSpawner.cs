using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] Coin _coinPrefab;


    public void StartCoinSpawn()
    {
        StartCoroutine(SpawnCoin());
        Debug.Log("StartCour");
    }


    public void StopCoinSpawn()
    {
        //StopCoroutine(SpawnCoin());
        StopAllCoroutines();
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
