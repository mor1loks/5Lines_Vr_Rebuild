using System;
using UnityEngine;
using UnityEngine.InputSystem;
public enum SceneActionState
{
    None,
    Radio,
    Scheme,
    Measure
}
public abstract class BaseActionButton : MonoBehaviour
{
    [SerializeField] protected bool NonAos;
    public Action<SceneActionState> SceneActionButtonEvent;
    [SerializeField] protected InputActionProperty ActionProp;
    public bool NonAosActionButton => NonAos;
    protected void Start()
    {
        SceneObjectsHolder.Instance.AddSceneActionButton(this);
    }
    protected virtual void OnEnable()
    {
        ActionProp.action.performed += OnActionPerformed;
    }
    protected virtual void OnDisable()
    {
        ActionProp.action.performed -= OnActionPerformed;
    }
    protected abstract void OnActionPerformed(InputAction.CallbackContext c);

}
