using System.Collections;
using UnityEngine;

public class MeasureActionObject : BaseActionObject
{
    [SerializeField] private ShupController _shupController;
    [SerializeField] private PointerDevice _pointerDevice;
    [SerializeField] private Ampermetr _amper;
    private bool _activeAmper = false;
    public override void Activate()
    {
        base.Activate();
        if (!CanActivate)
            return;
        if (!_activeAmper)
        {
            _activeAmper = true;
            _amper.EnableAmper(_activeAmper);
            StartCoroutine(ButtonsActivatorAsync());
        }
        else Deactivate();
    }
    public override void Deactivate()
    {
        base.Deactivate();
        _activeAmper = false;
        _amper.EnableAmper(false);
        _shupController.ResetShupPosition();
        SceneObjectsHolder.Instance.ResetMeasureButtonsCurrentList();
        _pointerDevice.SetValue(1);
    }

    private IEnumerator ButtonsActivatorAsync()
    {
        yield return new WaitForSeconds(0.2f);
        SceneObjectsHolder.Instance.ActivateMeasureButtonsCurrentList();
        SceneObjectsHolder.Instance.CanTouch = false;
    }
}
