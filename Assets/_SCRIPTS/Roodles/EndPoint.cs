using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private float _deltaScale;
    private Vector3 _scale;

    private void Start()
    {
        _scale = new Vector3(_deltaScale, _deltaScale, _deltaScale);
    }

    private void Update()
    {
        if (transform.localScale.x < 36)
            transform.localScale += _scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hexagon"))
        {
            collision.gameObject.SetActive(false);
        }
    }

}
