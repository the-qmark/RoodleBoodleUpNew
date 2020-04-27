using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPref;
    [SerializeField] private BubblePickUp _bubbleMovePref;

    private GameObject _bubble;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _bubble = Instantiate(_bubbleMovePref.gameObject, transform.position, Quaternion.identity);
        _bubble.SetActive(false);
    }

    private int GetChance()
    {
        int r = Random.Range(0, 20);
        Debug.Log("random = " + r);
        return r;
    }


    public void Spawn()
    {
        int _chance = GetChance();

        if (_chance > 17)
        {
            SpawnBubble();
        }
        else 
        if (_chance > 8)
        {
            SpawnCoin();
        }
    }


    private void SpawnCoin()
    {
        //if (GetChance() > 8)
        //{
        //    GameObject coin = Instantiate(_coinPref.gameObject, transform.position, Quaternion.identity);
        //    Destroy(coin, 30);
        //}

        GameObject coin = Instantiate(_coinPref.gameObject, transform.position, Quaternion.identity);
        Destroy(coin, 30);
    }


    private void SpawnBubble()
    {
        //if (GetChance() > 15)
        //{
        //    GameObject bubble = Instantiate(_bubbleMovePref.gameObject, transform.position, Quaternion.identity);
        //    Destroy(bubble, 30);
        //}

        Vector3 _point = _camera.WorldToViewportPoint(_bubble.transform.position);
        Debug.Log("point = " + _point.y);

        if (_point.y < 0)
        {
            _bubble.SetActive(false);
        }

        if (_bubble.activeSelf)
        {
            return;
        }
        else
        {
            _bubble.transform.position = transform.position;
            _bubble.SetActive(true);
        }

        //GameObject bubble = Instantiate(_bubbleMovePref.gameObject, transform.position, Quaternion.identity);
        //Destroy(bubble, 30);
    }
}
