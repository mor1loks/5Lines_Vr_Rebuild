using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMovingObject : BaseSideMovingObject
{
    [SerializeField] private GameObject _objectToMove;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;
    [SerializeField] private float _speed;
    private float _moveX;
    private float _moveY;
    public override void SetMoveSide(Vector3 moveVector)
    {
        _moveX = moveVector.x;
        _moveY = moveVector.y;
    }

    private void Update()
    {
        if (_objectToMove == null)
            return;
        TryMove();
    }

    protected override void TryMove()
    {
        TryMoveHorizontal();
        TryMoveVertical();
    }
    private void TryMoveHorizontal()
    {
        if (_objectToMove.transform.localPosition.x < _maxX)
            _objectToMove.transform.localPosition += new Vector3(_moveX, 0) * _speed * Time.deltaTime;
    }
    private void TryMoveVertical()
    {
        if (_objectToMove.transform.localPosition.y < _maxY)
            _objectToMove.transform.localPosition += new Vector3(0, _moveY) * _speed * Time.deltaTime;
        if (_objectToMove.transform.localPosition.y > _minY)
            _objectToMove.transform.localPosition += new Vector3(0, _moveY) * _speed * Time.deltaTime;
    }
}
