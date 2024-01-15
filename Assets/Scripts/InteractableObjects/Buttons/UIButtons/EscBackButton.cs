using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscBackButton : BaseUIButton
{
    private MainMenuController _menuController;
    private EscButton _escButton;
    protected override void Click()
    {
        _menuController = FindObjectOfType<MainMenuController>();
        _escButton = FindObjectOfType<EscButton>();
        _menuController.TeleportToGame();
    }
}
