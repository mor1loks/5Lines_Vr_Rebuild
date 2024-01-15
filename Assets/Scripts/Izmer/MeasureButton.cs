using AosSdk.Core.PlayerModule.Pointer;

public class MeasureButton : BaseButton
{
    public override void OnClicked(InteractHand interactHand)
    {
        ShupPositionChanger.Instance.SetNewShupPositon(transform, SceneAOSObject.ObjectId);
    }
}