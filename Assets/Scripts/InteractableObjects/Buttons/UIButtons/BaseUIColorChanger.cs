using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ButtonColorState
{
    Disabled,
    Active,
    Enabled
}

public abstract class BaseUIColorChanger : MonoBehaviour
{
    public void ChangeColorState(ButtonColorState state)
    {
        switch (state) 
        {
            case ButtonColorState.Disabled:
                DisabledState();
                break;
            case ButtonColorState.Active:
                ActiveState();
                break;
            case ButtonColorState.Enabled:
                EnabledState();
                break;
        }
    }
    protected virtual void DisabledState()
    {

    }
    protected virtual void ActiveState()
    {

    }
    protected virtual void EnabledState()
    {

    }
}
