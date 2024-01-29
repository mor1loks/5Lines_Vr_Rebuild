using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public enum MoveState
{
    None,
    Up,
    Down,
    Left,
    Right
}
public class MoveUiButton : BaseUIButton
{
    [SerializeField] private MoveState _moveState;
    private BaseSideMovingObject _baseSideMovingObject;
    public void SetSideMovingObject(BaseSideMovingObject obj)
    {
        _baseSideMovingObject = obj;
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (_baseSideMovingObject != null)
            _baseSideMovingObject.SetMoveSide(_moveState);
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (_baseSideMovingObject != null)
            _baseSideMovingObject.SetMoveSide(MoveState.None);
    }
}
