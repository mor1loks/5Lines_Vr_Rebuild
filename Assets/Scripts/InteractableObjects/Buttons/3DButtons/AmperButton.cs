using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class AmperButton : BaseButton
{
    [SerializeField] private Ampermetr _ampermetr;
    [SerializeField] protected Transform _amperPosition;
    private bool _amper = false;
    private void OnEnable()
    {
        BackButton.BackButtonClickedEvent += OnDisableMeasureButtons;
    }
    private void OnDisable()
    {
        BackButton.BackButtonClickedEvent -= OnDisableMeasureButtons;
    }
    public override void OnClicked(InteractHand interactHand)
    {
        if (!_amper)
        {
            _amper = true;
            StartCoroutine(ButtonsActivatorAsync());
        }
        else
        {
            _amper = false;
            ShupController shup = FindObjectOfType<ShupController>();
            shup.OnResetShupPosition();
            SceneObjectsHolder.Instance.ResetMeasureButtonsCurrentList();
            PointerDevice device = FindObjectOfType<PointerDevice>();
            device.SetValue(1);
            SceneObjectsHolder.Instance.CanTouch = true;
        }
        _ampermetr.EnableAmper(_amper, _amperPosition);
    }
    private void OnDisableMeasureButtons()
    {
        _amper = false;
        _ampermetr.EnableAmper(_amper, _amperPosition);
        SceneObjectsHolder.Instance.ResetMeasureButtonsCurrentList();
        PointerDevice device = FindObjectOfType<PointerDevice>();
        device.SetValue(1);
    }
    private IEnumerator ButtonsActivatorAsync()
    {
        yield return new WaitForSeconds(0.2f);
        if (_amper)
        {
            SceneObjectsHolder.Instance.ActivateMeasureButtonsCurrentList();
            SceneObjectsHolder.Instance.CanTouch = false;
        }
    }
}

