using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
[AosSdk.Core.Utils.AosObject(name: "AosObject")]
public class SceneAosObject : AosObjectBase
{
    [AosEvent(name: "OnClickObject")]
    public event AosEventHandlerWithAttribute OnClickObject;
    [SerializeField] private bool _button;
    [SerializeField] private bool _place;
    [SerializeField] private BackButtonObject _backButton;
    [SerializeField] private Transform _reactionPos;

    public void InvokeOnClick()
    {
        if (_backButton != null)
        {
            BackButtonsActivator.Instance.SetBackButtonObject(_backButton);
        }
            
            OnClickObject?.Invoke(ObjectId);
        if (_place&& _reactionPos!=null)
        {
            ReactionHelper reactionHelper = FindObjectOfType<ReactionHelper>();
            if (reactionHelper != null)
                reactionHelper.ChangeReactionHelperPosition(_reactionPos);
        }
    }

    public void ActionWithObject(string actionName)
    {
        OnClickObject?.Invoke(actionName);
    }
}
