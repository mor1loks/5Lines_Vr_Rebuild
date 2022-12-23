using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class EnableImageButton : BaseButton
{
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
        base.OnClicked(interactHand);
        if (_object.activeSelf)
        {
      
                SoundPlayer.Instance.PlayMapOpenSound();
            _object.SetActive(false);
        }
        else
        {
            SoundPlayer.Instance.PlayMapCloseSound();
            _object.SetActive(true);
        }
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
