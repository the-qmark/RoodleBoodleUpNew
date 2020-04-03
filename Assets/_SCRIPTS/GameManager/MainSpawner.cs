using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPref;
    [SerializeField] private BubblePickUp _bubbleMovePref;

    private int _chance;

    private void SetChance()
    {
        _chance = Random.Range(0, 20);
    }

    public void SpawnCoin()
    {
        SetChance();
        if (_chance > 0)
        {
            GameObject coin = Instantiate(_coinPref.gameObject, transform.position, Quaternion.identity);
            Destroy(coin, 30);
        }
        //Debug.Log("Spawn coin  = " + _chance);
    }

    public void SpawnBubble()
    {
        SetChance();
        if (_chance > 0)
        {
            GameObject bubble = Instantiate(_bubbleMovePref.gameObject, transform.position, Quaternion.identity);
            Destroy(bubble, 30);
        }
    }

    
}
