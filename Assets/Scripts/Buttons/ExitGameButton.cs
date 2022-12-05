using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameButton : BaseButton
{
    [SerializeField] private string _actionName;
    public override void OnClicked(InteractHand interactHand)
    {
        API api = FindObjectOfType<API>();
        api.OnInvokeNavAction(_actionName);
    }
}
