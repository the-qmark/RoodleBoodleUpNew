using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingsButton;
    [SerializeField] private GameObject _shopButton;

    public void GameStart()
    {
        iTween.RotateTo(_settingsButton, new Vector3(0, 0, 180), 5);
        //iTween.RotateAdd(_settingsButton, new Vector3(0, 0, 180), 4);
        //iTween.RotateBy(_settingsButton, new Vector3(0, 0, 180), 4);
        //iTween.rota
        iTween.RotateTo(_shopButton, new Vector3(0, 0, -180), 5);
        //iTween.RotateTo(_settingsButton, iTween.Hash()
    }

    

}
