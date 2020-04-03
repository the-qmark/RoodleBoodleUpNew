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

    public UnityEvent GameOver;
    public UnityEvent ReachedNewStage;

    private RoodleController _roodleController;
    private RoodleAutoController _roodleAuto;
    private RoodleAutoMove _roodleAutoMove;
    private BubbleMove _roodleBubbleMove;

    private void Start()
    {
        _roodleController = GetComponent<RoodleController>();
        _roodleAuto = GetComponent<RoodleAutoController>();
        _roodleAutoMove = GetComponent<RoodleAutoMove>();
        _roodleBubbleMove = GetComponent<BubbleMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hexagon"))
        {
            //GameOver?.Invoke();
            //Debug.Log(transform.rotation.eulerAngles);
        }

        //if (collision.CompareTag("NewStage"))
        //{
        //    ReachedNewStage?.Invoke();
        //    Destroy(collision.gameObject);
        //}

        if (collision.TryGetComponent<Coin>(out Coin _coin))
        {
            _coin.PickUp();
        }

        if (collision.TryGetComponent<BubblePickUp>(out BubblePickUp _bubbleMove))
        {
            //Debug.ClearDeveloperConsole();
            //_autoMove.PickUp();
            //_roodleAutoMove.SetAutoMoveList(_autoMove._autoMoveInfo);


            //_roodleAuto.enabled = true;
            //_roodleAutoMove.enabled = true;

            transform.position = _bubbleMove.transform.position;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _roodleController.enabled = false;
            _roodleBubbleMove.enabled = true;

            //_roodleAuto.AddNewData(_autoMove.Rotation, _autoMove.Position);
        }
    }

    public void OnGameOver()
    {
        //GameOverEffect.Play();
        //mainRoodle.SetActive(false);
        RoodleData activeRoodle = _roodleController.ActiveRoodle;

        activeRoodle.RoodleSprite.enabled = false;
        activeRoodle.RoodleFlyEffect.SetActive(false);
        activeRoodle.RoodleGameOverEffect.Play();

        _roodleController.enabled = false;
        //_roodleAutoMove.enabled = false;

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        //Coroutine a = ReloadScene;

        StartCoroutine("ReloadScene");
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
