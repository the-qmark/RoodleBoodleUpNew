using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePickUp : MonoBehaviour
{
    [SerializeField] private BubbleMove _bubbleMove;
    [SerializeField] private AutoMoveForce _autoMoveForce;
    [SerializeField] private CircleCollider2D _collider;

    private void OnEnable()
    {
        _collider.enabled = true;
    }


    public void NewPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
        _autoMoveForce.ResetScale();
    }

    public void PickUp(RoodleController roodleController)
    {
        _bubbleMove.enabled = true;
        _collider.enabled = false;
    }
}
