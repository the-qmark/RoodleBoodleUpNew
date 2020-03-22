using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoodleAutoMove : MonoBehaviour
{
    [SerializeField] private RoodleController _roodleController;
    [SerializeField] private ParticleSystem _autoMoveEffect;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private CircleCollider2D _circleCollider;

    //private List<AutoMoveInfo> _autoMoveInfo = new List<AutoMoveInfo>();
    private List<AutoMoveInfo> _autoMoveInfo;

    private int _currentIndex = 0;

    private WaitForSeconds _delay = new WaitForSeconds(1f);

    public static bool IsActive;

    public AutoMoveEnd autoMoveEnd;

    private int _count;

    //public void AddData(Quaternion _rotation, Vector3 _position)
    //{
    //    _autoMoveInfo.Add(new AutoMoveInfo(_rotation, _position));
    //}

    public void SetAutoMoveList(List<AutoMoveInfo> auto)
    {
        _autoMoveInfo = auto;
    }

    private void OnEnable()
    {
        _currentIndex = 0;
        IsActive = true;
        _autoMoveEffect.gameObject.SetActive(true);
        transform.rotation = _autoMoveInfo[_currentIndex].Rotation;
        _count = _autoMoveInfo.Count;
        _circleCollider.enabled = false;
        //StartCoroutine(Move());
    }


    private void OnDisable()
    {
        //StopCoroutine(Move());
        _autoMoveEffect.gameObject.SetActive(false);
        IsActive = false;
        _autoMoveInfo.Clear();
        _circleCollider.enabled = true;
    }

    float step;
    //Debug.Log($"List = {_autoMoveInfo.Count}, index = {_currentIndex}");

    private void Update()
    {
        step = 200 * Time.deltaTime; // calculate distance to move

        transform.position = Vector3.MoveTowards(transform.position, _autoMoveInfo[_currentIndex].Position, step);

        if (Vector3.Distance(transform.position, _autoMoveInfo[_currentIndex].Position) < 0.01f)
        {
            if (_currentIndex < _count)
            {
                GetNewPosition();
            }
            else
            {
                //transform.rotation = Quaternion.Euler(0, 0, 0);
                //transform.position = new Vector2(0, transform.position.y + 30);
                this.enabled = false;
                _roodleController.enabled = true;
            }
            
        }
    }

    private void GetNewPosition()
    {
        _currentIndex++;

        if (_currentIndex == _count)
        {
            autoMoveEnd.Enable(transform.position);
            _autoMoveInfo.Add(new AutoMoveInfo(Quaternion.Euler(0, 0, 0), new Vector3(0, transform.position.y + 30, 0)));
        }
        Debug.Log(_currentIndex);
        transform.rotation = _autoMoveInfo[_currentIndex].Rotation;     
    }

    IEnumerator Move()
    {
        while (_currentIndex < _autoMoveInfo.Count)
        {
            transform.rotation = _autoMoveInfo[_currentIndex].Rotation;
            transform.position = _autoMoveInfo[_currentIndex].Position;

            _currentIndex++;

            if (_currentIndex == _autoMoveInfo.Count)
                autoMoveEnd.Enable(transform.position);

            yield return _delay;
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = new Vector2(0, transform.position.y + 30);
        

        enabled = false;
        _roodleController.enabled = true;
    }

}