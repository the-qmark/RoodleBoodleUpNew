using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private float _deltaScale;
    private Vector3 _scale;
    private IEnumerator scaleUpDown;

    public bool ScaleUp;



    private void Start()
    {
        _scale = new Vector3(_deltaScale, _deltaScale, _deltaScale);
        
    }

    private void OnEnable()
    {
        //StartCoroutine("ScaleUpDown");
        LeanTween.scale(this.gameObject, new Vector3(4f, 4f, 4f), 0.3f).setLoopPingPong();
    }

    private void OnDisable()
    {
        transform.localScale = new Vector3(3, 3, 3);
        ScaleUp = false;
        LeanTween.cancel(this.gameObject);
        //StopCoroutine(ScaleUpDown());
    }
    
    private void Update()
    {
        if (ScaleUp)
        {
            LeanTween.cancel(this.gameObject);
            //StopCoroutine("ScaleUpDown");
            if (transform.localScale.x < 12)
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

    //IEnumerator ScaleUpDown()
    //{
    //    Debug.Log("Scale");
    //    while (true)
    //    {
    //        iTween.ScaleTo(gameObject, new Vector3(3.5f, 3.5f, 3.5f), 3f);
    //        yield return new WaitForSeconds(0.5f);
    //        iTween.ScaleTo(gameObject, new Vector3(2.5f, 2.5f, 2.5f), 3f);
    //        yield return new WaitForSeconds(0.5f);
    //    }
    //}
}
