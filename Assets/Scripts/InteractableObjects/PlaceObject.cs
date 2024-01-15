using AosSdk.Core.PlayerModule.Pointer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : SceneObject
{
    [SerializeField] private BackButton _backButton;
    [SerializeField] private Transform _reactionPos;

    private ObjectWithAnimation _objectWithAnimation;

    public Action<BackButton> SetCurrentBackButtonEvent;
    public Action<Transform> SetReactionTransformEvent;
    public Action<ObjectWithAnimation> AddAnimationObjectEvent;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        if (_backButton != null)
            SetCurrentBackButtonEvent?.Invoke(_backButton);
        if (_reactionPos != null)
            SetReactionTransformEvent?.Invoke(_reactionPos);
           _objectWithAnimation = GetComponent<ObjectWithAnimation>();
        if (_objectWithAnimation != null)
        {
            _objectWithAnimation.PlayScriptableAnimationOpen();
            AddAnimationObjectEvent?.Invoke(_objectWithAnimation);
        }
       // InstanceHandler.Instance.BackTriggersHolder.EnableCurrentTrigger(true);
    }
}
