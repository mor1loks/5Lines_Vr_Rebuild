using AosSdk.Core.PlayerModule.Pointer;
<<<<<<< Updated upstream
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
=======
public class NextButton : BaseButton, INextButton
{
    protected API API;

    public event NextButtonPressed NextButtonPressedEvent;

    public NextButtonState CurrentState { get ; set; }

    protected override void Start()
    {
        base.Start();
        API = FindObjectOfType<API>();
    }
>>>>>>> Stashed changes
    public override void OnClicked(InteractHand interactHand)
    {
        ClickNextButton();
    }
    public void ClickNextButton()
    {
        if (CurrentState == NextButtonState.Start)
        {
<<<<<<< Updated upstream
            _api.OnInvokeNavAction("next");
            OnNextButtonPressed?.Invoke("next");
            Player.Instance.CanMove = false;
=======
            API.OnInvokeNavAction("next");
            NextButtonPressedEvent?.Invoke("next");
>>>>>>> Stashed changes
        }

        else if (CurrentState == NextButtonState.Fault)
        {
<<<<<<< Updated upstream
            _api.OnInvokeNavAction("start");
            OnNextButtonPressed?.Invoke("start");
            Player.Instance.CanMove = true;
=======
            API.OnInvokeNavAction("start");
            NextButtonPressedEvent?.Invoke("start");
>>>>>>> Stashed changes
        }
    }
}


