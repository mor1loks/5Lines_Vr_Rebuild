using System;
using UnityEngine;
using UnityEngine.InputSystem;
public enum SceneActionState
{
    Radio,
    Scheme,
    Measure
}
public class SceneActionButton : BaseActionButton
{
    [SerializeField] private SceneActionState _currentState;
    public Action<SceneActionState> SceneActionButtonEvent;
    protected override void OnActionPerformed(InputAction.CallbackContext c) => SceneActionButtonEvent?.Invoke(_currentState);
    private void Start()
    {
        SceneObjectsHolder.Instance.AddSceneActionButton(this);
    }
    public void InvokeActionEvent() => SceneActionButtonEvent?.Invoke(_currentState);
  
}
