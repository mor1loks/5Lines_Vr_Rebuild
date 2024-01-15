using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using System;
public class EnableImageButton : BaseButton
{
    public static Action MapButtonClickEvent;
    [SerializeField] private GameObject _object;
    [SerializeField] private BackButton _backButtonObject;

    private void OnEnable()
    {
        BackButton.BackButtonClickedEvent += OnDisableMap;
    }
    private void OnDisable()
    {
        BackButton.BackButtonClickedEvent -= OnDisableMap;
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
