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
    public override void Deactivate()
    {
        base.Deactivate();
        SoundPlayer.Instance.PlayMapCloseSound();
    }
}
