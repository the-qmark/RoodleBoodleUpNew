using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour
{
    private const string MaxScore = "MaxScore";

    private const string AcvtiveRoodle = "ActiveRoodle";
    
    
    void Awake()
    {
        if (!PlayerPrefs.HasKey(MaxScore))
            PlayerPrefs.SetInt(MaxScore, 0);

        if (!PlayerPrefs.HasKey(AcvtiveRoodle))
            PlayerPrefs.SetString(AcvtiveRoodle, "MAIN_ROODLE_PREFAB");
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

    /// <summary>
    /// Возвращает true если параметр соответствует установленному активному рудлу
    /// </summary>
    /// <param name="_name">Имя объекта</param>
    /// <returns></returns>
    public static bool CheckActive(string _name)
    {
        return PlayerPrefs.GetString(AcvtiveRoodle) == _name ? true : false;

        //if (PlayerPrefs.GetString(AcvtiveRoodle) == _name)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}

        //return PlayerPrefs.GetString(AcvtiveRoodle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
