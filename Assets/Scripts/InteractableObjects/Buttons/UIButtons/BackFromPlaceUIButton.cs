using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackFromPlaceUIButton : UIButtonWithColorChanger
{
    public static Action ClickBackFromPlaceUiButtonEvent;
    protected override void Click()
    {
        ClickBackFromPlaceUiButtonEvent?.Invoke();
    }
}