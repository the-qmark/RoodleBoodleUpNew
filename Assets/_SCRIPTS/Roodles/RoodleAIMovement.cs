using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoodleAIMovement : MonoBehaviour
{
    public float MovementSpeed;
    public float RotateSpeed;

    private float[] xPosition = { 5f, 10, 15f, 20f };
    private float[] zRotation = { 30, 40, 50, 60, 70, 80 };

    private Quaternion newRotate;
    private Vector3 newPosition;

    private int dir;
    private float step;
    private Rigidbody2D rb;

    private void Start()
    {
        //dir = Random.Range(1, 10);
        dir = Random.Range(1, 10) < 5 ? -1 : 1; // -1 влево
        rb = GetComponent<Rigidbody2D>();
        SetNewRotateAndPosition(out newRotate, out newPosition);
    }


    private void Update()
    {
        step = Time.deltaTime * RotateSpeed;
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotate, step);

        if (dir > 0) // вправо
        {
            if (transform.position.x >= newPosition.x)
            {
                Debug.Log("RIGHT");
                SetNewRotateAndPosition(out newRotate, out newPosition);
            }
        }
        else
        {
            if (transform.position.x <= newPosition.x)
            {
                Debug.Log("LEFT");
                SetNewRotateAndPosition(out newRotate, out newPosition);
            }
        }

    }


    private void FixedUpdate()
    {
        rb.velocity = transform.up * MovementSpeed * Time.fixedDeltaTime;
    }


    private void SetNewRotateAndPosition(out Quaternion _newRotate, out Vector3 _newPos)
    {
        dir *= -1;

        int zIndex = Random.Range(0, zRotation.Length);
        _newRotate = Quaternion.Euler(0, 0, -zRotation[zIndex] * dir);

        int xIndex = Random.Range(0, xPosition.Length);
        _newPos = new Vector3(xPosition[xIndex] * dir, 0, 0);

        Debug.Log($"Dir = {dir}");
        Debug.Log($"New rotate = {-zRotation[zIndex] * dir}");
        Debug.Log($"New position = {xPosition[xIndex] * dir}");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hexagon"))
        {
            Destroy(collision.gameObject);
        }
    }
}
