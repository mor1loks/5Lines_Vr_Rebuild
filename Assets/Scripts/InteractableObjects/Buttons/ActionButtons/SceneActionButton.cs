using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneActionButton : BaseActionButton
{

    [SerializeField] private SceneActionState _currentState;

    protected override void OnActionPerformed(InputAction.CallbackContext c) => SceneActionButtonEvent?.Invoke(_currentState);
    public void InvokeActionButtonEvent() => SceneActionButtonEvent?.Invoke(_currentState);

}
