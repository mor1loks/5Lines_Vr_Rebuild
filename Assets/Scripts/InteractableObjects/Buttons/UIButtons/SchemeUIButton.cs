using System;
using UnityEngine;

public class SchemeUIButton : BaseUIButton
{
    [SerializeField] private bool _side;
    public Action<bool> ClickEvent;
    protected override void Click() => ClickEvent?.Invoke(_side);

}
