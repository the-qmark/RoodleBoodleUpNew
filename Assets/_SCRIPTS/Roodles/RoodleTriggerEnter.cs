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

    public UnityEvent GameOver;
    public UnityEvent ReachedNewStage;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hexagon"))
        {
            //GameOver?.Invoke();
        }

        if (collision.CompareTag("NewStage"))
        {
            ReachedNewStage?.Invoke();
            Destroy(collision.gameObject);
        }
    }

    public void OnGameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //public void OnReachedNewStage()
    //{

    //}
}
