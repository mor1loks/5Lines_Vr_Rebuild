using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopActionObject : BaseActionObject
{
    [SerializeField] private GameObject _canvas;
    public override void Activate()
    {
        Debug.Log(Active + " ACTIVE");
        _canvas.SetActive(true);
        Active = true;
    }

    public override void Deactivate()
    {
        Debug.Log(Active + " DEACTIVE");
        _canvas.SetActive(false);
        Active = false;
    }
}
