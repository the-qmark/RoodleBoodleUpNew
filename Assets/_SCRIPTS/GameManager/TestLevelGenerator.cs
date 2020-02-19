using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevelGenerator : MonoBehaviour
{
    public GameObject MainLine;
    public int CounOfLine;
    public float DeltaY;
    private float currentY;

    
    void Start()
    {
        currentY = DeltaY;
        for (int i = 0; i < CounOfLine; i++)
        {
            Instantiate(MainLine, new Vector3(0, currentY, 0), Quaternion.identity);
            currentY += DeltaY;
        }
    }
}
