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
    public NextButtonState CurrentState;

    public override void OnClicked(InteractHand interactHand)
    {
        if (CurrentState == NextButtonState.Start)
        {
            OnNextButtonPressed?.Invoke("next");
            Player.Instance.CanMove = false;
        }
     
        else if (CurrentState == NextButtonState.Fault)
        {
            OnNextButtonPressed?.Invoke("start");
            Player.Instance.CanMove = true;
        }
         
    }
}


