using AosSdk.Core.PlayerModule.Pointer;
using System;
using UnityEngine;
public class BackButton : BaseButton
{
    public static Action BackButtonClickedEvent;
    [SerializeField] private BackTriggerObject _backTriggerObj;

    private const string ACTION_NAME = "back";
    public override void OnClicked(InteractHand interactHand)
    {
        BackButtonClickedEvent?.Invoke();
        API api = FindObjectOfType<API>();
        api.OnInvokeNavAction(ACTION_NAME);
        SceneObjectsHolder.Instance.CanTouch = true;
        _backTriggerObj.EnableObject(false);
    }
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        if (_backTriggerObj != null)
        {
            _backTriggerObj.EnableObject(true);
            _backTriggerObj.SetButtonInvoke(this);
        }
    }
}
