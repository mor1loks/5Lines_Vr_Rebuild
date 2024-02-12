using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class StrelkaButton : BaseButton
{
    [SerializeField] private bool _side;
    public override void OnClicked(InteractHand interactHand)
    {
        var strelka = SceneObjectsHolder.Instance.StrelkaAOS;
        var radioContainer = SceneObjectsHolder.Instance.RadioButtonsContainer;
        var location = SceneObjectsHolder.Instance.LocationTextController;
        if (_side)
        {
            strelka.TrySwitchStrelkaPlus();
            AOSRadio button = radioContainer.GetButtonPlus(location.CurrentLocation());
            button.InvokeOnClick();
        }
        else
        {
            strelka.TrySwitchStrelkaMinus();
            AOSRadio button = radioContainer.GetButtonMinus(location.CurrentLocation());
            button.InvokeOnClick();
        }
        StrelkaAOS.StrelkaChangedEvent?.Invoke();
    }
}
