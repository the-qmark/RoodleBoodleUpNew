using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopShake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.rotate(gameObject, new Vector3(0f, 0f, 2f), 0.2f).setLoopPingPong();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
