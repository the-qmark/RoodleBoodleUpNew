using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    [SerializeField] private GameObject _idleEffect;
    [SerializeField] private GameObject _pickUpEffect;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private CircleCollider2D _circleCollider;

    public static bool IsActive;

    public List<AutoMoveInfo> _autoMoveInfo = new List<AutoMoveInfo>();


    public void AddData(Quaternion _rotation, Vector3 _position)
    {
        _autoMoveInfo.Add(new AutoMoveInfo(_rotation, _position));
    }


    private void Start()
    {
        Destroy(gameObject, 20f);
        IsActive = true;
    }


    private void OnDestroy()
    {
        IsActive = false;
    }


    public void PickUp()
    {
        _idleEffect.SetActive(false);
        _pickUpEffect.SetActive(true);
        _spriteRenderer.enabled = false;
        _circleCollider.enabled = false;
        IsActive = false;
        Destroy(gameObject, 3f);
    }
}

public class AutoMoveInfo
{
    public Quaternion Rotation;
    public Vector3 Position;

    public AutoMoveInfo(Quaternion _rotation, Vector3 _position)
    {
        Rotation = _rotation;
        Position = _position;
    }
}