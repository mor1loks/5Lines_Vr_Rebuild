using System.Collections;
using UnityEngine;

public class MeasureActionObject : DesktopActionObject
{
    [SerializeField] private ShupController _shupController;
    [SerializeField] private PointerDevice _pointerDevice;
    private Ampermetr _amper;
    private void Start()
    {
        _amper = Canvas.GetComponent<Ampermetr>();
        if (_amper == null)
            Debug.LogError($"{gameObject.name} Canvas object must be Ampermetr");
    }
    public override void Activate()
    {
        if (!CanActivate)
            return;
        if (!_amper.Active)
        {
            _amper.EnableAmper(true);
            Active = true;
            StartCoroutine(ButtonsActivatorAsync());
        }
        else Deactivate();
    }
    public override void Deactivate()
    {
        _amper.EnableAmper(false);
        Active = false;
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
