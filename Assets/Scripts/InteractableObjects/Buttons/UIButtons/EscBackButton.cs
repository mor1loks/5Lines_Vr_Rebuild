using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscBackButton : BaseUIButton
{
    [SerializeField]private DesktopMenuController _menuController;
    protected override void Click()
    {
        _menuController.TeleportToGame();
    }
}
