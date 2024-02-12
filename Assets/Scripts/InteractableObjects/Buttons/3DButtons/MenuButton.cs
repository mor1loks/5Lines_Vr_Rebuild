using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : BaseButton
{
    private bool _show = false;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        DesktopMenuController menuController = FindObjectOfType<DesktopMenuController>();
        if(!_show)
        {
            menuController.TeleportToMenu();
            _show = true;
        }
        else
        {
            menuController.TeleportToGame();
            _show =false;
        }

    }
    public void ChangeShowValue(bool value)
    {
        _show = value;
    }
}
