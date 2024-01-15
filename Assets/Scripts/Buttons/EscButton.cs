using AosSdk.Core.Utils;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class EscButton : MonoBehaviour
{
    public Action EscButtonClickEvent;
    [SerializeField] private InputActionProperty _menuAction;
    [SerializeField] private MainMenuController _menuController;
    [SerializeField] private API _api;
    private bool _show = false;
    public bool Show { get; set; } = false;
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
        EscButtonClickEvent?.Invoke();
        if (!Show)
            return;
        if(!_show)
        {
            _menuController.TeleportToMenu();
            _show = true;
            _api.OnMenuInvoke();
        }
        else
        {
            _show = false;
            _menuController.TeleportToGame();
        }
    }
    public void ChangeShowValue(bool value)
    {
        _show = value;
    }
}
