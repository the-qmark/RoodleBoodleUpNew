using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour
{
    private const string MaxScore = "MaxScore"; 
    
    
    void Awake()
    {
        if (!PlayerPrefs.HasKey(MaxScore))
            PlayerPrefs.SetInt(MaxScore, 0);
    }


    public static void UpdateMaxScore(int _newScore)
    {
        int _score = PlayerPrefs.GetInt(MaxScore) < _newScore ? _newScore : PlayerPrefs.GetInt(MaxScore);
        PlayerPrefs.SetInt(MaxScore, _score);
    }

    public static int GetMaxScore()
    {
        return PlayerPrefs.GetInt(MaxScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
