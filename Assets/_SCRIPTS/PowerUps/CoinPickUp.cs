using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    [SerializeField] private CircleCollider2D _circleCollider;
    [SerializeField] private Coin[] _coins = new Coin[3];

    private int _chance;

    void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * 100, Space.Self);

        if (Input.GetKeyDown(KeyCode.G))
        {
            ResetState();
        }
    }

    public void PickUp()
    {
        //_coin.PickUp();
        foreach (Coin coin in _coins)
        {
            if (coin.gameObject.activeSelf)
                coin.PickUp();
        }    
        _circleCollider.enabled = false;
    }

    public void ResetState()
    {
        _chance = Random.Range(0, 20);

        foreach (Coin coin in _coins)
        {
            if (coin.gameObject.activeSelf)
                coin.gameObject.SetActive(false);
        }

        //Debug.Log("Coin chance = " + _chance);

        if (_chance > 18)
        {
            SpawnThreeCoins();
        } 
        else
        if (_chance > 15)
        {
            SpawnTwoCoins();
        }
        else
        if (_chance > 5)
        {
            SpawnOneCoin();
        }
        _circleCollider.enabled = true;
        //_coin.ResetState();
    }

    private void SpawnOneCoin()
    {
        _coins[0].transform.localPosition = new Vector3(0, 0, 0);
        _coins[0].gameObject.SetActive(true);
        _coins[0].ResetState();
    }

    private void SpawnTwoCoins()
    {
        _coins[0].transform.localPosition = new Vector3(-3, 0, 0);
        _coins[0].gameObject.SetActive(true);
        _coins[0].ResetState();

        _coins[1].transform.localPosition = new Vector3(3, 0, 0);
        _coins[1].gameObject.SetActive(true);
        _coins[1].ResetState();
    }

    private void SpawnThreeCoins()
    {
        _coins[0].transform.localPosition = new Vector3(-3, 2, 0);
        _coins[0].gameObject.SetActive(true);
        _coins[0].ResetState();

        _coins[1].transform.localPosition = new Vector3(3, 2, 0);
        _coins[1].gameObject.SetActive(true);
        _coins[1].ResetState();

        _coins[2].transform.localPosition = new Vector3(0, -3, 0);
        _coins[2].gameObject.SetActive(true);
        _coins[2].ResetState();
    }
}
