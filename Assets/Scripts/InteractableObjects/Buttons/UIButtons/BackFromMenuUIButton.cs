using System;
using UnityEngine;

public class BackFromMenuUIButton : BaseUIButton
{
    public static Action BackButtonClickEvent;
    [SerializeField] private bool _event;
    protected override void Click()
    {
        if (_event)
        {
            API.OnInvokeNavAction("back");
        }

        BackButtonClickEvent?.Invoke();
        var menuController = FindObjectOfType<DesktopMenuController>();
        menuController.TeleportToGame();
    }
}
