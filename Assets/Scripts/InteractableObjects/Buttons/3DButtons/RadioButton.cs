using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class RadioButton : BaseButton
{
    [SerializeField] private Diet _diet;
    [SerializeField] protected Transform _dietPosition;
    private bool _radio = false;
    private void OnEnable()
    {
        BackButton.BackButtonClickedEvent += OnBackClicked;
    }
    private void OnDisable()
    {
        BackButton.BackButtonClickedEvent -= OnBackClicked;
    }
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        DietEnabler();
    }
    private void DietEnabler()
    {
        if (!_radio) _radio = true;
        else _radio = false;
        _diet.EnableDiet(_radio, _dietPosition);
    }
    private void OnBackClicked()
    {
        if(_radio)
        {
            _radio = false;
            _diet.EnableDiet(_radio, _dietPosition);

        }
    }
}
