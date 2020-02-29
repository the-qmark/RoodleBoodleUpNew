﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveData
{
    public Quaternion Rotation;
    public Vector3 Position;
    public int Dir;
    public float MovementSpeed;
    public float RotateSpeed;

    public AutoMoveData()
    {
       
    }

    public AutoMoveData(Quaternion rotation, Vector3 position, int dir, float moveSpeed, float rotateSpeed)
    {
        Rotation = rotation;
        Position = position;
        Dir = dir;
        MovementSpeed = moveSpeed;
        RotateSpeed = rotateSpeed;
    }
}