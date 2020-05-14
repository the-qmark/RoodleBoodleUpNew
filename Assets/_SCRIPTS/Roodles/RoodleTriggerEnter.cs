using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

public class RoodleTriggerEnter : MonoBehaviour
{
    public ParticleSystem GameOverEffect;
    public GameObject mainRoodle;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private AdForSecondLife _adForSecondLife;

    public UnityAction GameOver;
    public UnityAction ReachedNewStage;

    private RoodleController _roodleController;
    //private BubbleMove _roodleBubbleMove;
    private BubbleFollow _bubbleFollow;

    //private IEnumerator RestartCoroutine;

    private void OnEnable()
    {
        GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        GameOver -= OnGameOver;
    }

    private void Start()
    {
        _roodleController = GetComponent<RoodleController>();
       // _roodleBubbleMove = GetComponent<BubbleMove>();
        _bubbleFollow = GetComponent<BubbleFollow>();
        //RestartCoroutine = Restart();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hexagon"))
        {
            GameOver?.Invoke();
        }

        if (collision.TryGetComponent<CoinPickUp>(out CoinPickUp _coin))
        {
            _coin.PickUp();
        }

        if (collision.TryGetComponent<BubblePickUp>(out BubblePickUp _bubbleMove))
        {
            transform.position = _bubbleMove.transform.position;
            transform.rotation = Quaternion.Euler(0, 0, 0);

            _roodleController.enabled = false;
            _bubbleMove.PickUp(_roodleController);
            _bubbleFollow.enabled = true;
        }
    }


    public void OnGameOver()
    {
        RoodleData activeRoodle = _roodleController.ActiveRoodle;

        activeRoodle.Image.enabled = false;
        activeRoodle.FlyEffect.SetActive(false);
        activeRoodle.GameOverEffect.Play();

        _roodleController.enabled = false;

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }


    //public void RestartGame()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}


    //IEnumerator Restart()
    //{
    //    yield return new WaitForSeconds(2f);
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
}
