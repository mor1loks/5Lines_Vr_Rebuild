using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonWithObjectEnabler : BaseUIButton
{
    [SerializeField] private EnableObjectWithAction _enabableObject;
    protected override void Click()
    {
        _enabableObject.EnableAction();
    }
}
