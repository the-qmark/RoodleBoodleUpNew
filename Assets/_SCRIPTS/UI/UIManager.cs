using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingsRotatePoint;
    [SerializeField] private GameObject _shopRotatePoint;

    [SerializeField] private GameObject _settingsButton;
    [SerializeField] private GameObject _shopButton;

    [SerializeField] private GameObject _secondLifeButton;

    private void Start()
    {
        //LeanTween.rotate(_settingsButton, new Vector3(0, 0, 5), 0.3f).setLoopPingPong();
        LeanTween.scale(_secondLifeButton, new Vector3(1.1f, 1.1f, 1.1f), 0.3f).setLoopPingPong();
        
        //LeanTween.cancel(_shopButton);


    }

    public void GameStart()
    {
        //iTween.RotateTo(_settingsRotatePoint, new Vector3(0, 0, 180), 5);

        LeanTween.rotate(_settingsRotatePoint, new Vector3(0, 0, -180), 1);
        LeanTween.rotate(_shopRotatePoint, new Vector3(0, 0, 180), 1);

        //LeanTween.rotate(_settingsRotatePoint, new Vector3(0, 0, 100), 1).setLoopPingPong();

        //iTween.RotateAdd(_settingsButton, new Vector3(0, 0, 180), 4);
        //iTween.RotateBy(_settingsButton, new Vector3(0, 0, 180), 4);
        //iTween.rota

        //iTween.RotateTo(_shopRotatePoint, new Vector3(0, 0, -180), 5);

        //iTween.RotateTo(_settingsButton, iTween.Hash()
    }

    

}
