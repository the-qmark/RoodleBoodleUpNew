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

    private void Start()
    {
        _roodleController = GetComponent<RoodleController>();
        _roodleAuto = GetComponent<RoodleAutoController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hexagon"))
        {
            GameOver?.Invoke();
            //Debug.Log(transform.rotation.eulerAngles);
        }

        if (collision.CompareTag("NewStage"))
        {
            ReachedNewStage?.Invoke();
            Destroy(collision.gameObject);
        }

        if (collision.TryGetComponent<Coin>(out Coin _coin))
        {
            _coin.PickUp();
        }

        if (collision.TryGetComponent<AutoMove>(out AutoMove _autoMove))
        {
            Debug.ClearDeveloperConsole();
            _autoMove.PickUp();
            transform.position = _autoMove.transform.position;
            transform.rotation = _autoMove.transform.rotation;
            _roodleAuto.enabled = true;
            _roodleController.enabled = false;
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
        _roodleAuto.enabled = false;

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
