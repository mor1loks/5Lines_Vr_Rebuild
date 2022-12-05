using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMenuButton : BaseButton
{
    [SerializeField] private EscButton _escButton;
    [SerializeField] private MenuButton _menuButton;
    [SerializeField] private MainMenuController _mainController;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        _escButton.ChangeShowValue(false);
        _menuButton.ChangeShowValue(false);
        _mainController.TeleportToPreviousLocation();

    }
}
