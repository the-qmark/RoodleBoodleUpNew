using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveEnd : MonoBehaviour
{
    public GameObject EndPoint;

    public void Enable(Vector3 _position)
    {
        Vector3 pos = new Vector3(0, _position.y+50, 0);
        var endPoin = Instantiate(EndPoint, pos, Quaternion.identity);
        Destroy(endPoin, 5);
    }  
}
