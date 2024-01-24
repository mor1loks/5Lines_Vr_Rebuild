using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MoveUiButton : BaseUIButton
{
    [SerializeField] private Vector3 _currentMoveSide;
    private BaseSideMovingObject _baseSideMovingObject;
    public void SetSideMovingObject(BaseSideMovingObject obj)
    {
        _baseSideMovingObject = obj;
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (_baseSideMovingObject != null)
            _baseSideMovingObject.SetMoveSide(_currentMoveSide);
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (_baseSideMovingObject != null)
            _baseSideMovingObject.SetMoveSide(Vector3.zero);
    }
}
