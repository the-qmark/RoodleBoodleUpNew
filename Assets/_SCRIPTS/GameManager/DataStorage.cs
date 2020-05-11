using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour
{
    private const string MAX_SCORE = "MaxScore";
    private const string ACTIVE_ROODLE = "ActiveRoodle";
    private const string COINS = "Coins";
    
    
    void Awake()
    {
        if (!PlayerPrefs.HasKey(MAX_SCORE))
            PlayerPrefs.SetInt(MAX_SCORE, 0);

        if (!PlayerPrefs.HasKey(ACTIVE_ROODLE))
            PlayerPrefs.SetString(ACTIVE_ROODLE, "MAIN_ROODLE_PREFAB");

        if (!PlayerPrefs.HasKey(COINS))
            PlayerPrefs.SetInt(COINS, 0);
    }


    public static void UpdateMaxScore(int _newScore)
    {
        int _score = PlayerPrefs.GetInt(MAX_SCORE) < _newScore ? _newScore : PlayerPrefs.GetInt(MAX_SCORE);
        PlayerPrefs.SetInt(MAX_SCORE, _score);
    }

    public static int GetMaxScore()
    {
        return PlayerPrefs.GetInt(MAX_SCORE);
    }

    /// <summary>
    /// Возвращает true если параметр соответствует установленному активному рудлу
    /// </summary>
    /// <param name="_name">Имя объекта</param>
    /// <returns></returns>
    public static bool CheckActiveRoodle(string _name)
    {
        return PlayerPrefs.GetString(ACTIVE_ROODLE) == _name ? true : false;
    }

    public static void SetActiveLetter(string _name)
    {
        PlayerPrefs.SetInt(_name, 1);
    }

    public static bool CheckActiveLetter(string _name)
    {
        return PlayerPrefs.GetInt(_name) == 1 ? true : false;
    }

    public static void AddCoin(int value)
    {
        value += PlayerPrefs.GetInt(COINS);
        PlayerPrefs.SetInt(COINS, value);
    }
}
