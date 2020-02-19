using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoodleAIScale : MonoBehaviour
{
    public float DeltaScale;
    private Vector3 reduceScaleVector;

    private void Start()
    {
        reduceScaleVector = new Vector3(DeltaScale, DeltaScale, DeltaScale);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ReduceScale();
        }
    }

    private void ReduceScale()
    {
        if (transform.localScale.x <= 2)
            return;
        transform.localScale -= reduceScaleVector;
    }
}
