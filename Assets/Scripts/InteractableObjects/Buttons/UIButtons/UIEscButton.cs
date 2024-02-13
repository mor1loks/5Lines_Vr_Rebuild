using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEscButton : UIButtonWithColorChanger
{
    [SerializeField] private EscButton _escButton;
    protected override void Click()
    {
        _escButton.InvokeEscEvent();
    }
}
