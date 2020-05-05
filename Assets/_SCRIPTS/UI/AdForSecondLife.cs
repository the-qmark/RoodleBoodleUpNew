using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdForSecondLife : MonoBehaviour
{
    [SerializeField] private Button _noThanksButton;
    private IEnumerator _noThanks;


    void Start()
    {
        LeanTween.moveLocal(gameObject, new Vector2(0, 0), 0.3f);
        _noThanks = NoThanks();
        StartCoroutine(_noThanks);
    }


    IEnumerator NoThanks()
    {
        yield return new WaitForSeconds(2f);
        _noThanksButton.gameObject.SetActive(true);
    }


    public void ShowPanel()
    {
        gameObject.SetActive(true);
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.3f);
    }
}
