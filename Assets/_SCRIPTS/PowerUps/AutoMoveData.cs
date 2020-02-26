using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveData : MonoBehaviour
{
    public Quaternion Rotation;
    public Vector3 Position;

    public AutoMoveData(Quaternion rotation, Vector3 position)
    {
        Rotation = rotation;
        Position = position;
    }
}
