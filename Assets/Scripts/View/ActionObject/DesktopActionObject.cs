using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopActionObject : BaseActionObject
{
    [SerializeField] private GameObject _canvas;
    public override void Activate()
    {
        _canvas.SetActive(true);
    }

    public override void Deactivate()
    {
        _canvas.SetActive(false);
    }
}
