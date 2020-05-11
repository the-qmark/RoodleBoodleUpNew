using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleFollow : MonoBehaviour
{
    [SerializeField] private BubbleMove _bubble;

    private void OnEnable()
    {
        _bubble.AutoMoveEnd += OnAutoMoveEnd;
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
    }
}
