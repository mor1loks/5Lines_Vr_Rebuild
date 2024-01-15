using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopStartScreenView : BaseStartScreenView
{
    [SerializeField] private CursorManager _cursorManager;
    [SerializeField] private GameObject _menuObject;

    protected override void DisableStartScreen()
    {
       _menuObject.SetActive(false);
    }
    public override void SetStartScreenText(string headerText, string commentText, string buttonText, NextButtonState state)
    {
        base.SetStartScreenText(headerText, commentText, buttonText, state);
        _cursorManager.EnableCursor(true);
    }
    protected override void OnHideStartScreen(string value)
    {
        base.OnHideStartScreen(value);
        if(value =="start")
            _cursorManager.EnableCursor(false);
    }
}
