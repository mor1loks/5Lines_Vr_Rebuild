using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackActionObject : BaseActionObject
{
    public static Action BackEvent;
    public override void Activate()
    {
        base.Activate();
        BackEvent?.Invoke();
    }
}
