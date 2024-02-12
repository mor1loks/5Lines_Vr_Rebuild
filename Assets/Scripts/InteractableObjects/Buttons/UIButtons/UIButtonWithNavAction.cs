using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonWithNavAction : BaseUIButton
{
    [SerializeField] private string _action;
    protected override void Click()
    {
        API.OnInvokeNavAction(_action);
    }
}
