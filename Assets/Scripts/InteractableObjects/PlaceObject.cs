using AosSdk.Core.PlayerModule.Pointer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : SceneObject
{
    [SerializeField] private Camera _camera;
    [SerializeField] private string _backLocationName;

    private ObjectWithAnimation _objectWithAnimation;
    public Action<ObjectWithAnimation> AddAnimationObjectEvent;
    public Action<Camera> CameraChangedEvent;
    public Action<string> SetBackLocationNameEvent;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        _objectWithAnimation = GetComponent<ObjectWithAnimation>();
        if (_objectWithAnimation != null)
        {
            _objectWithAnimation.PlayScriptableAnimationOpen();
            AddAnimationObjectEvent?.Invoke(_objectWithAnimation);
        }
        SetBackLocationNameEvent?.Invoke(_backLocationName);
        if (_camera == null || !SceneObjectsHolder.Instance.ModeController.DesktopMode)
            return;
        CameraChangedEvent?.Invoke(_camera);
        EnableHighlight(false);

        // InstanceHandler.Instance.BackTriggersHolder.EnableCurrentTrigger(true);
    }
}
