using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class AmperButton : BaseButton
{
    [SerializeField] private Ampermetr _ampermetr;
    [SerializeField] private BackButtonObject _backButton;
    [SerializeField] protected Transform _amperPosition;
    private bool _amper = false;
    private void OnEnable()
    {
        _backButton.BackButtonClickEvent += OnDisableMeasureButtons;
    }
    private void OnDisable()
    {
        _backButton.BackButtonClickEvent -= OnDisableMeasureButtons;
    }
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
 
            MovingButtonsController.Instance.HideAllButtons();
            if (!_amper)
            {
                _amper = true;
            StartCoroutine(ButtonsActivatorAsync());
      
            }
            else
            {
                _amper = false;
                ShupController shup = FindObjectOfType<ShupController>();
                shup.ResetShupPosition();
            MeasureButtonsActivator.Instance.DeactivateAllButtons();
            PointerDevice device = FindObjectOfType<PointerDevice>();
            device.SetValue(1);
            AOSColliderActivator.Instance.CanTouch = true;
        }
            _ampermetr.EnableAmper(_amper, _amperPosition);
        

    }
    private void OnDisableMeasureButtons()
    {
        _amper = false;
        _ampermetr.EnableAmper(_amper, _amperPosition);
        MeasureButtonsActivator.Instance.DeactivateAllButtons();
        API api = FindObjectOfType<API>();
    }
    private IEnumerator ButtonsActivatorAsync()
    {
        yield return new WaitForSeconds(0.2f);
        if(_amper)
        {
            MeasureButtonsActivator.Instance.ActivateButtonsWithList();
            AOSColliderActivator.Instance.CanTouch = false;
        }
       
    }
}

