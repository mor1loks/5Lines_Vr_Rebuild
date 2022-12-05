using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(MeasureAosButton))]
public class MeasureButton : BaseButton
{
    private MeasureAosButton _measureAOSButton;
    public override void OnClicked(InteractHand interactHand)
    {
        _measureAOSButton = GetComponent<MeasureAosButton>();
        ShupPositionChanger.Instance.SetNewShupPositon(transform, _measureAOSButton.ObjectId);
    }
}