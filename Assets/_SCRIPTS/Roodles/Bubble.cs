using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private float _deltaScale;
    private Vector3 _scale;

    public bool ScaleUp;

    private void Start()
    {
        _scale = new Vector3(_deltaScale, _deltaScale, _deltaScale);
    }

    private void OnDisable()
    {
        transform.localScale = new Vector3(3, 3, 3);
        ScaleUp = false;
    }

    private void Update()
    {
        if (ScaleUp)
        {
            if (transform.localScale.x < 9)
            {
                transform.localScale += _scale;
                transform.Translate(transform.up);
            } 
            else
            {
                gameObject.SetActive(false);
                transform.localPosition = new Vector3(0, 0, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!ScaleUp)
            return;

        if (collision.CompareTag("Hexagon"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
