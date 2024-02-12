using AosSdk.Core.PlayerModule.Pointer;

public class ExitGameButton : BaseButton
{
    public override void OnClicked(InteractHand interactHand)
    {
        API api = FindObjectOfType<API>();
        api.OnInvokeNavAction("exit");
    }
}
