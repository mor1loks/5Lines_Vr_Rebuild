using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class BackButtonObject : BaseButton
{
    public UnityAction BackButtonClickEvent;
    [SerializeField] private string _locationBackName;
    [SerializeField] private ScenaAosObjectWithAnimation _animationObject;
    [SerializeField] private BackTriggerObject _backTriggerObj;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        BackButtonClickEvent?.Invoke();
        MovingButtonsController.Instance.HideAllButtons();
        API api = FindObjectOfType<API>();
        api.OnInvokeNavAction(BackButtonsActivator.Instance.ActionToInvoke);
        ShupController shup = FindObjectOfType<ShupController>();
        shup.ResetShupPosition();
        if (_animationObject != null)
        {
            _animationObject.PlayCloseAnimation();
        }
        AOSColliderActivator.Instance.CanTouch = true;
        BackButtonsActivator.Instance.SetBackButtonObject(null);
        _backTriggerObj.EnableBackTriggerObject(false);
    }
    public override void EnableButton(bool value)
    {
        base.EnableButton(value);
        if (_backTriggerObj != null)
        {
            _backTriggerObj.EnableBackTriggerObject(true);
            _backTriggerObj.SetButtonInvoke(this);
        }
    }
}
