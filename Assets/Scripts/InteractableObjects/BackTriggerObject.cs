using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using UnityEngine;
[RequireComponent(typeof(Collider))]

public class BackTriggerObject : BaseObject
{
    private BackButton _currentBackButton;
    private InteractHand _hand;
    private void Start()
    {
        IsHoverable = false;
        IsClickable = false;
    }
    private void OnTriggerEnter(Collider col)
    {
        var aosObject = col.GetComponentInParent<AosObjectBase>();
        if (!aosObject)
            return;
        if (_currentBackButton != null)
            _currentBackButton.OnClicked(_hand);
        EnableObject(false);
    }
    public override void EnableObject(bool value)
    {
        GetComponent<Collider>().enabled = value;
    }
    public void SetButtonInvoke(BackButton obj)
    {
        _currentBackButton = obj;
    }
}
