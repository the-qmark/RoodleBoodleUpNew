using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    public UnityAction GameStarted;


    public static bool GameIsStart;

    private void Start()
    {
        GameIsStart = false;
        _audio.volume = (float)(DataStorage.GetVolume() / 100);
        Debug.Log("On Start = " + DataStorage.GetVolume() / 100);
    }


    public void GameStart()
    {
        GameIsStart = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameIsStart)
        {
            Application.Quit();
        }
    }
}
