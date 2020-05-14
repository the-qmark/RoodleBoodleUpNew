using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleFollow : MonoBehaviour
{
    [SerializeField] private BubbleMove _bubble;
    [SerializeField] private CircleCollider2D _collider2D;

    private void OnEnable()
    {
        _bubble.AutoMoveEnd += OnAutoMoveEnd;
        _collider2D.enabled = false;
    }

    private void OnDisable()
    {
        _bubble.AutoMoveEnd -= OnAutoMoveEnd;
    }

    private void Update()
    {
        transform.position = _bubble.transform.position;
    }

    private void OnAutoMoveEnd()
    {
        enabled = false;
        _collider2D.enabled = true;
    }
}
