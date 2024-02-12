using AosSdk.Core.PlayerModule.Pointer;
using System;
using UnityEngine;

public class MeasureButton : BaseButton
{
    public Action <Transform, string>MeasurePositionEvent;
    public override void OnClicked(InteractHand interactHand) => MeasurePositionEvent?.Invoke(transform, SceneAOSObject.ObjectId);
}