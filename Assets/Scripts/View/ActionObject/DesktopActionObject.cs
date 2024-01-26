using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopActionObject : BaseActionObject
{
    [SerializeField] private GameObject _canvas;
    public override void Activate()
    {
        if (!CanActivate)
            return;
        _canvas.SetActive(true);
        Active = true;
    }

    public override void Deactivate()
    {
        _canvas.SetActive(false);
        Active = false;
    }
}
