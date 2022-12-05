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
        MainMenuController menuController = FindObjectOfType<MainMenuController>();
        if(!_show)
        {
            menuController.TeleportToMainMenuLocation();
            _show = true;
        }
        else
        {
            menuController.TeleportToPreviousLocation();
            _show =false;
        }

    }
    public void ChangeShowValue(bool value)
    {
        _show = value;
    }
}
