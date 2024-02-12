using System;
using UnityEngine;
public enum SceneActionState
{
    None,
    Radio,
    Scheme,
    Measure,
    Back
}

public class BaseActionObject : MonoBehaviour
{
    protected bool CanActivate { get; set; } = false;
    public SceneActionState SceneActionState => CurrentState;
    [SerializeField] protected SceneActionState CurrentState;
    [SerializeField] protected BaseActionButton BaseActionButton;
    [SerializeField] protected UIButtonWithColorChanger BaseUIButton;
    protected virtual void Start()
    {
        BaseActionButton.ActionButtonEvent += Activate;
        BaseUIButton.ClickButtonEvent += Activate;
        if(CurrentState==SceneActionState.None)
            CanActivate = true;
        if (CurrentState == SceneActionState.Back)
            CanActivate = false;
    }
    public void Enable()
    {
        BaseUIButton.BaseUIColorChanger.ActivateState();
        CanActivate = true;
    }
    public virtual void Activate()
    {
        if (!CanActivate)
            return;
        SceneObjectsHolder.Instance.ActionButtonsHolder.InVokeOnClick(CurrentState);
    }
    public virtual void Deactivate()
    {
        Debug.Log("Deactivate " + gameObject.name);
    }
    public virtual void Disable()
    {
        Deactivate();
        CanActivate = false;
        BaseUIButton.BaseUIColorChanger.DeactivateState();
    }
}
