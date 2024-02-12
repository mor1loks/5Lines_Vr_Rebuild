using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCanvasButton : BaseUIButton
{
    public delegate void ButtonClick();
    public event ButtonClick BackButtonClickEvent;
    protected override void Click()
    {
        BackButtonClickEvent?.Invoke();
    }
}
