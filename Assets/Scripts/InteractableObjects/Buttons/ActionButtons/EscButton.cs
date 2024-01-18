using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class EscButton : BaseActionButton
{
    public Action EscButtonEvent;
    protected override void OnActionPerformed(InputAction.CallbackContext c) => EscButtonEvent?.Invoke();
}
