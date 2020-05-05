using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private RoodleTriggerEnter _roodleTrigger;
    [SerializeField] private AdForSecondLife _adForSecondLife;
    [SerializeField] private ScoreCounter _scoreCounter;

    private IEnumerator RestartCoroutine;
    private IEnumerator AdForSecondLifeCoroutine;

    private void OnEnable()
    {
        _roodleTrigger.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _roodleTrigger.GameOver -= OnGameOver;
    }

    private void Start()
    {
        RestartCoroutine = RestartDelay();
        AdForSecondLifeCoroutine = AdForSecondLifeDelay();
    }

    private void OnGameOver()
    {
        if (_scoreCounter.CurrentScore >= 200)
        {
            StartCoroutine(AdForSecondLifeCoroutine);
        }
        else
        {
            StartCoroutine(RestartCoroutine);
        }
    }

    IEnumerator RestartDelay()
    {
        yield return new WaitForSeconds(2f);
        Restart();
    }

    IEnumerator AdForSecondLifeDelay()
    {
        yield return new WaitForSeconds(1f);
        _adForSecondLife.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
