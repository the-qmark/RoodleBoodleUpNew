using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoodleAutoMove : MonoBehaviour
{
    [SerializeField] private RoodleController _roodleController;
    
    private List<AutoMoveInfo> _autoMoveInfo = new List<AutoMoveInfo>();

    private int _currentIndex = 0;

    private WaitForSeconds _delay = new WaitForSeconds(0.7f);

    public static bool IsActive;

    public void AddData(Quaternion _rotation, Vector3 _position)
    {
        _autoMoveInfo.Add(new AutoMoveInfo(_rotation, _position));
    }

    private void OnEnable()
    {
        _currentIndex = 0;
        IsActive = true;
        StartCoroutine(Move());
    }

    private void OnDisable()
    {
        StopCoroutine(Move());
        IsActive = false;
    }

    IEnumerator Move()
    {
        while(_currentIndex < _autoMoveInfo.Count-1)
        {
            transform.rotation = _autoMoveInfo[_currentIndex+1].Rotation;
            transform.position = _autoMoveInfo[_currentIndex+1].Position;

            _currentIndex++;

            yield return _delay;
        }

        enabled = false;
        _roodleController.enabled = true;
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
