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
            //YOffset = Mathf.Abs(transform.position.y - Roodle.position.y);
            isLookAt = true;
        }
    }


    void LateUpdate()
    {
        if (!isLookAt)
            return;
        //transform.Translate(transform.up * 65 * Time.deltaTime, Space.World);
        newPos = new Vector3(0, Roodle.position.y, -10);
        transform.position = newPos;
        //transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * 50);
        //transform.Translate(Vector3.up);
    }
}
