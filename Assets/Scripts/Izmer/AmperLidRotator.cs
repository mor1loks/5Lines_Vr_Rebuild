using AosSdk.Core.PlayerModule.Pointer;
using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class AmperLidRotator : SceneObject
{
    [SerializeField] private InputActionProperty _wheelAction;
    public Action <bool> RotateButton;
    private bool _canRotate;
    private void OnEnable()
    {
        _wheelAction.action.performed += OnMouseWheelRotate;
    }
    private void OnDisable()
    {
        _wheelAction.action.performed -= OnMouseWheelRotate;
    }
    public override void OnHoverIn(InteractHand interactHand)
    {
        base.OnHoverIn(interactHand);
        _canRotate = true;
    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        base.OnHoverOut(interactHand);
        _canRotate = false;
    }
    private void OnMouseWheelRotate(InputAction.CallbackContext obj)
    {
        if (!_canRotate)
            return;
        float rotate = obj.ReadValue<float>();
        bool result = rotate > 0;
        RotateButton?.Invoke(result);
    }
}
