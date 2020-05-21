using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveForce : MonoBehaviour
{

    [SerializeField] private Collider2D _collider2D;
    
    public void ResetScale()
    {
        transform.localScale = new Vector3(8, 8, 8);
        _collider2D.enabled = true;
    }


    public void ScaleUp()
    {
        //Vector3 refScale = transform.localScale;
        //refScale += new Vector3(0.5f, 0.5f, 0.5f);

        LeanTween.scale(gameObject, new Vector3(40f, 40f, 40f), 2f);
    }

    public void ScaleDown()
    {
        //Vector3 refScale = transform.localScale;
        //refScale += new Vector3(0.5f, 0.5f, 0.5f);

        LeanTween.scale(gameObject, new Vector3(0f, 0f, 0f), 0.5f);
    }

    private void Update()
    {
        if (transform.localScale.x <= 0.2f)
        {
            _collider2D.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CoinPickUp>(out CoinPickUp coin))
        {
            coin.PickUp();
        }

        //if (!ScaleUp)
        //    return;

        if (collision.CompareTag("Hexagon"))
        {
            //collision.gameObject.SetActive(false);
            LeanTween.scale(collision.gameObject, Vector3.zero, 0.3f);
        }

    }
}
