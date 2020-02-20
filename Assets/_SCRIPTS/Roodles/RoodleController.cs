using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoodleController : MonoBehaviour
{
    public float Speed;
    private float _currentSpeed = 0;

    public float Sensitivity;
    private float _currentSensitivity = 0;

    private Camera cam;
    private Rigidbody2D rb;

    private Vector3 currentPos;
    private Vector3 nextPos;
    private float deltaRot;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }


    void Update()
    {

#if UNITY_EDITOR
        if(Input.GetMouseButtonDown(0))
        {
            currentPos = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            nextPos = cam.ScreenToWorldPoint(Input.mousePosition);
            deltaRot = currentPos.x - nextPos.x;
            //transform.Rotate(Vector3.forward, deltaRot * Time.deltaTime);
            currentPos = nextPos;

            transform.Rotate(Vector3.forward, deltaRot * _currentSensitivity * Time.deltaTime);
        }
#endif
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * _currentSpeed * Time.fixedDeltaTime;
    }


    public void OnGameStarted()
    {
        _currentSpeed = Speed;
        _currentSensitivity = Sensitivity;
    }
}
