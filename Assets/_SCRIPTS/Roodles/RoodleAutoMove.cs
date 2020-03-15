using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoodleAutoMove : MonoBehaviour
{
    private List<AutoMoveInfo> _autoMoveInfo = new List<AutoMoveInfo>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class AutoMoveInfo
{
    public Quaternion Rotation;
    public Vector3 Position;

    public AutoMoveInfo(Quaternion rotation, Vector3 position)
    {
        Rotation = rotation;
        Position = position;
    }
}
