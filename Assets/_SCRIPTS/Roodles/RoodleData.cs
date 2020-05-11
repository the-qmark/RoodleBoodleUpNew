using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoodleData : MonoBehaviour
{
    public SpriteRenderer Image;
    public GameObject FlyEffect;
    public ParticleSystem GameOverEffect;

    private RoodleController _roodleController;

    private void Awake()
    {
        _roodleController = GetComponentInParent<RoodleController>();
        
        if (DataStorage.CheckActiveRoodle(gameObject.name))
        {
            _roodleController.ActiveRoodle = this;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}