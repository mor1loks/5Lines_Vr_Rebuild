using AosSdk.Core.PlayerModule;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;

public enum NextButtonState
{
    Start,
    Fault
}
public class NextButton : BaseButton
{
    public UnityAction<string> OnNextButtonPressed;
    [HideInInspector] public NextButtonState CurrentState;
    protected API API;
    protected override void Start()
    {
        base.Start();
        API = FindObjectOfType<API>();
    }
    public override void OnClicked(InteractHand interactHand)
    {
        if (CurrentState == NextButtonState.Start)
        {
            API.OnInvokeNavAction("next");
            OnNextButtonPressed?.Invoke("next");
            Player.Instance.CanMove = false;
        }
     
        else if (CurrentState == NextButtonState.Fault)
        {
            API.OnInvokeNavAction("start");
            OnNextButtonPressed?.Invoke("start");
            Player.Instance.CanMove = true;
        }
    }
}


