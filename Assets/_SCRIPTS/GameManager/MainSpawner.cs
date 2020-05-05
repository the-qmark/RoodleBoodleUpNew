using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MainSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPref;
    [SerializeField] private BubblePickUp _bubbleMovePref;
    [Space]
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private GameObject _coinsContainer;
    [SerializeField] private RoodleController _roodle;

    private GameObject[] _coinsPool = new GameObject[25];

    private GameObject _bubble;
    private Camera _camera;

    private int GetChance() => Random.Range(0, 20);


    private void OnEnable()
    {
        _scoreCounter.SpawnLimitReached += OnSpawnLimitReached;
    }


    private void OnDisable()
    {
        _scoreCounter.SpawnLimitReached -= OnSpawnLimitReached;
    }


    private void Awake()
    {
        for (int i = 0; i < _coinsPool.Length; i++)
        {
            _coinsPool[i] = Instantiate(_coinPref.gameObject, transform.position, Quaternion.identity, _coinsContainer.transform);
            _coinsPool[i].SetActive(false);
        }
    }


    private void Start()
    {
        _camera = Camera.main;
        _bubble = Instantiate(_bubbleMovePref.gameObject, transform.position, Quaternion.identity);
        _bubble.SetActive(false);
    }


    private void OnSpawnLimitReached()
    {
        int _chance = GetChance();

        if (_chance > -1)
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
        Vector3 _point = new Vector3();

        foreach (GameObject coin in _coinsPool)
        {
            if (coin.activeSelf == true)
            {
                _point = _camera.WorldToViewportPoint(coin.transform.position);

                if (_point.y < 0)
                    coin.SetActive(false);
            }
        }

        GameObject _coin = _coinsPool.FirstOrDefault(c => c.activeSelf == false);

        if (_coin != null)
        {
            _coin.transform.position = transform.position;
            _coin.SetActive(true);
        }
    }


    private void SpawnBubble()
    {
        if (Vector2.Distance(transform.position, _roodle.transform.position) < 200)
        {
            return;
        }

        Vector3 _point = _camera.WorldToViewportPoint(_bubble.transform.position);
        //Debug.Log("point = " + _point.y);

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
    }
}
