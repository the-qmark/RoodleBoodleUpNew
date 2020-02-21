using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Roodle;

    private float YOffset;
    private Vector3 newPos;

    private bool isLookAt;

    void Start()
    {
        //YOffset = Mathf.Abs(transform.position.y - Roodle.position.y);
    }

    private void Update()
    {
        if (Roodle.position.y >= transform.position.y && !isLookAt)
        {
            YOffset = Mathf.Abs(transform.position.y - Roodle.position.y);
            isLookAt = true;
        }
    }


    void LateUpdate()
    {
        if (!isLookAt)
            return;

        newPos = new Vector3(0, Roodle.position.y + YOffset, -10);
        transform.position = Vector3.Lerp(transform.position, newPos, 1f);
    }
}
