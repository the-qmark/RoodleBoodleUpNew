using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Roodle;
    private float YOffset;
    private Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        YOffset = Mathf.Abs(transform.position.y - Roodle.position.y);
    }


    void LateUpdate()
    {
        newPos = new Vector3(0, Roodle.position.y + YOffset, -10);
        transform.position = newPos;
    }
}
