using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrelkaUiButton : BaseUIButton
{
    [SerializeField] private bool _side;
    protected override void Click()
    {
        var strelka = SceneObjectsHolder.Instance.StrelkaAOS;
        var radioContainer = SceneObjectsHolder.Instance.RadioButtonsContainer;
        var location = SceneObjectsHolder.Instance.LocationTextController;
        if (_side)
        {
            strelka.TrySwitchStrelkaPlus();
            AOSRadio button = radioContainer.GetButtonPlus(location.GetLocationName());
            button.InvokeOnClick();
        }
        else
        {
            strelka.TrySwitchStrelkaMinus();
            AOSRadio button = radioContainer.GetButtonMinus(location.GetLocationName());
            button.InvokeOnClick();
        }
        StrelkaAOS.StrelkaChangedEvent?.Invoke();
    }
}
