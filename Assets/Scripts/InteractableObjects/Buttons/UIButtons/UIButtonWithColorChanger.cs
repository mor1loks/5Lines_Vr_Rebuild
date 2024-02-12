using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BaseUIColorChanger))]

public class UIButtonWithColorChanger : BaseUIButton
{
    private BaseUIColorChanger _baseUiColorChanger;
    public BaseUIColorChanger BaseUIColorChanger => _baseUiColorChanger;
    protected override void Start()
    {
        base.Start();
        _baseUiColorChanger = GetComponent<BaseUIColorChanger>();
    }
}
