using UnityEngine;
using UnityEngine.InputSystem;

public class ActionButtonWithObject : BaseActionButton
{
    [SerializeField] private GameObject _obj;
    protected override void OnActionPerformed(InputAction.CallbackContext c)
    {
        bool active = !_obj.activeSelf;
        _obj.SetActive(active);
    }
}
