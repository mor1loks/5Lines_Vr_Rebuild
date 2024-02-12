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
    public bool CanChangeState { get; set; } = true;
    public void ChangeColorState(ButtonColorState state)
    {
        switch (state) 
        {
            case ButtonColorState.Disabled:
                DeactivateState();
                break;
            case ButtonColorState.Active:
                ActivateState();
                break;
            case ButtonColorState.Enabled:
                EnabledState();
                break;
        }
    }
    public virtual void DeactivateState()
    {
    }
    public virtual void ActivateState()
    {
        if (!CanChangeState)
            return;
    }
    public virtual void EnabledState()
    {
        if (!CanChangeState)
            return;
    }
}
