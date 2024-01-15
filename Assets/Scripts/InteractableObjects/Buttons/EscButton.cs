using AosSdk.Core.Utils;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class EscButton : MonoBehaviour
{
    public Action EscButtonEvent;

    [SerializeField] private InputActionProperty _menuAction;
    [SerializeField] private API _api;
    private void OnEnable()
    {
        _menuAction.action.performed += OnShowMenu;
    }
    private void OnDisable()
    {
        _menuAction.action.performed -= OnShowMenu;
    }
    private void OnShowMenu(InputAction.CallbackContext c)
    {
        EscButtonEvent?.Invoke();
    }

}
