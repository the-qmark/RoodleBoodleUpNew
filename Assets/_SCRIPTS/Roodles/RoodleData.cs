using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoodleData : MonoBehaviour
{
    public SpriteRenderer RoodleSprite;
    public GameObject RoodleFlyEffect;
    public ParticleSystem RoodleGameOverEffect;

    private RoodleTriggerEnter _roodleTrigger;
    private RoodleController _roodleController;

    private void Awake()
    {
        _roodleController = GetComponentInParent<RoodleController>();
        
        if (DataStorage.CheckActiveRoodle(gameObject.name))
        {
            _roodleController.ActiveRoodle = this;
        }
    }
}
