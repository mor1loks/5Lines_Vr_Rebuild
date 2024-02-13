using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMenuButton : BaseButton
{
    [SerializeField] private EscButton _escButton;
    [SerializeField] private MenuButton _menuButton;
    [SerializeField] private DesktopMenuController _mainController;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        _menuButton.ChangeShowValue(false);
        _mainController.TeleportToGame();
    }
}
