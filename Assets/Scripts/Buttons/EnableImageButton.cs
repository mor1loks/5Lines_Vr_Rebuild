using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using System;
public class EnableImageButton : BaseButton
{
    public static Action MapButtonClickEvent;
    [SerializeField] private GameObject _object;
    [SerializeField] private BackButtonObject _backButtonObject;

    private void OnEnable()
    {
        _backButtonObject.BackButtonClickEvent += OnDisableMap;
    }
    private void OnDisable()
    {
        _backButtonObject.BackButtonClickEvent -= OnDisableMap;
    }
    public override void OnClicked(InteractHand interactHand)
    {
        MapButtonClickEvent?.Invoke();
    }
    private void OnDisableMap()
    {
        if (_object.activeSelf)
        {
            SoundPlayer.Instance.PlayMapCloseSound();
            _object.SetActive(false);
        }
  
    }
}
