using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPref;
    [SerializeField] private BubblePickUp _bubbleMovePref;


    private int GetChance()
    {
        return Random.Range(0, 20);
    }


    public void SpawnCoin()
    {
        if (GetChance() > 8)
        {
            GameObject coin = Instantiate(_coinPref.gameObject, transform.position, Quaternion.identity);
            Destroy(coin, 30);
        }
    }


    public void SpawnBubble()
    {
        if (GetChance() > 15)
        {
            GameObject bubble = Instantiate(_bubbleMovePref.gameObject, transform.position, Quaternion.identity);
            Destroy(bubble, 30);
        }
    }

    
}
