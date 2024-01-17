using UnityEngine;
using UnityEngine.InputSystem;

public abstract class BaseActionButton : MonoBehaviour
{
    [SerializeField] protected InputActionProperty ActionProp;

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
