using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdForSecondLife : MonoBehaviour
{
    
    public void ShowPanel()
    {
        gameObject.SetActive(true);
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.3f);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
