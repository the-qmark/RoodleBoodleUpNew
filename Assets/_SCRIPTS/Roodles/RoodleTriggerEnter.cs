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
        //Time.timeScale = 0.2f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hexagon"))
        {
            GameOver?.Invoke();
        }

        if (collision.CompareTag("NewStage"))
        {
            ReachedNewStage?.Invoke();
            Destroy(collision.gameObject, 5);
        }

        if (collision.TryGetComponent<Coin>(out Coin _coin))
        {
            _coin.PickUp();
        }

        if (collision.TryGetComponent<AutoMove>(out AutoMove _autoMove))
        {
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
        GameOverEffect.Play();
        mainRoodle.SetActive(false);
        _roodleController.enabled = false;
        _roodleAuto.enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        StartCoroutine("ReloadScene");
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //public void OnReachedNewStage()
    //{

    //}
}
