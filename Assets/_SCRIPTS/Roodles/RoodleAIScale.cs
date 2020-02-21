using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoodleAIScale : MonoBehaviour
{
    public float DeltaDownScale;
    private Vector3 downScaleVector;

    private void Start()
    {
        downScaleVector = new Vector3(DeltaDownScale, DeltaDownScale, DeltaDownScale);
    }

    private void Update()
    {

    }

    public void OnReachedNewStage()
    {
        if (transform.localScale.x <= 2)
            return;
        transform.localScale -= downScaleVector;
    }
}
