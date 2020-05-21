using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MainSpawner : MonoBehaviour
{
    [SerializeField] private CoinPickUp _coinPickUp;
    [SerializeField] private BubblePickUp _bubbleMovePref;
    [Space]
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private GameObject _coinsContainer;
    [SerializeField] private RoodleController _roodle;
    [SerializeField] private BubbleFollow _bubbleFollow;

    private CoinPickUp[] _coinsPool = new CoinPickUp[10];

    //private BubblePickUp _bubble;
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
            _coinsPool[i] = Instantiate(_coinPickUp, transform.position, Quaternion.identity, _coinsContainer.transform);
            _coinsPool[i].gameObject.SetActive(false);
        }

        _camera = Camera.main;

        //_bubble = Instantiate(_bubbleMovePref, transform.position, Quaternion.identity);
        //_bubbleFollow.SetBubble(_bubbleMovePref);
        //_bubbleMovePref.gameObject.SetActive(false);
        //_bubble.gameObject.SetActive(false);  
    }


    private void OnSpawnLimitReached()
    {
        int _chance = GetChance();

        if (_chance > 16)
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

        foreach (CoinPickUp coinPickUp in _coinsPool)
        {
            if (coinPickUp.gameObject.activeSelf == true)
            {
                _point = _camera.WorldToViewportPoint(coinPickUp.transform.position);

                if (_point.y < 0)
                    coinPickUp.gameObject.SetActive(false);
            }
        }

        CoinPickUp _coinPickUp = _coinsPool.FirstOrDefault(c => c.gameObject.activeSelf == false);

        if (_coinPickUp != null)
        {
            _coinPickUp.gameObject.transform.position = transform.position;
            _coinPickUp.gameObject.SetActive(true);
            _coinPickUp.ResetState();
        }
    }


    private void SpawnBubble()
    {
        if (Vector2.Distance(transform.position, _roodle.transform.position) < 200)
        {
            return;
        }

        Vector3 _point = _camera.WorldToViewportPoint(_bubbleMovePref.transform.position);
        //Debug.Log("point = " + _point.y);

        if (_point.y < 0)
        {
            _bubbleMovePref.gameObject.SetActive(false);
        }

        if (_bubbleMovePref.gameObject.activeSelf)
        {
            return;
        }
        else
        {
            //_bubbleMovePref.transform.position = transform.position;
            _bubbleMovePref.NewPosition(transform.position);
            _bubbleMovePref.gameObject.SetActive(true);
        }
    }
}
