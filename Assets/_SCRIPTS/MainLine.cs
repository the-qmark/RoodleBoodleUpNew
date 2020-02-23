using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLine : MonoBehaviour
{
    private List<GameObject> _hexagons = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {


        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            if (transform.GetChild(0).GetChild(i).gameObject.tag == "Hexagon")
            {
                _hexagons.Add(transform.GetChild(0).GetChild(i).gameObject);
            }
        }

        for (int i = 0; i < transform.GetChild(1).childCount; i++)
        {
            if (transform.GetChild(1).GetChild(i).gameObject.tag == "Hexagon")
            {
                _hexagons.Add(transform.GetChild(1).GetChild(i).gameObject);
            }
        }
    }

    public void SetAcitiveTrue()
    {
        _hexagons.ForEach(p => p.SetActive(true));
    }
}
