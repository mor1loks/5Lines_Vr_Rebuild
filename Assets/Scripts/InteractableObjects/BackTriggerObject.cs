using System.Collections.Generic;
using System.Linq;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using UnityEngine;
[RequireComponent(typeof(Collider))]

public class BackTriggerObject : BaseObject
{
    private BackButtonObject _tempBackButton;
    private InteractHand _hand;
    

    public override void OnClicked(InteractHand interactHand)
    {
        return;
    }
    public override void OnHoverIn(InteractHand interactHand)
    {
        return;
    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        return;
    }

    private void OnTriggerEnter(Collider col)
    {
        var aosObject = col.GetComponentInParent<AosObjectBase>();
        if (!aosObject)
            return;
        if (_tempBackButton != null)
            _tempBackButton.OnClicked(_hand);
        EnableBackTriggerObject(false);
    }
    public void EnableBackTriggerObject(bool value)
    {
        GetComponent<Collider>().enabled = value;
    }
public void SetButtonInvoke(BackButtonObject obj)
    {
        _tempBackButton = obj;
    }
}
