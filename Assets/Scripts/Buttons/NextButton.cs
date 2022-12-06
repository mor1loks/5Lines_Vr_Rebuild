using AosSdk.Core.PlayerModule;
using AosSdk.Core.PlayerModule.Pointer;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private API _api;
    public override void OnClicked(InteractHand interactHand)
    {
        if (CurrentState == NextButtonState.Start)
        {
            _api.OnInvokeNavAction("next");
            Player.Instance.CanMove = false;
        }
     
        else if (CurrentState == NextButtonState.Fault)
        {
            _api.OnInvokeNavAction("start");
            Player.Instance.CanMove = true;
        }
    }
}


