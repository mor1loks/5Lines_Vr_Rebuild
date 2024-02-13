using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchemeActionObject : DesktopActionObject
{
    public override void Activate()
    {
        base.Activate();
        SoundPlayer.Instance.PlayMapOpenSound();
    }

}
