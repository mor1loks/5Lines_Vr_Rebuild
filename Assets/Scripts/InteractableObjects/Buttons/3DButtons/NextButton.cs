using AosSdk.Core.PlayerModule.Pointer;
public class NextButton : BaseButton, INextButton
{
    protected API API;

    public event NextButtonPressed NextButtonPressedEvent;

    public NextButtonState CurrentState { get; set; }

    protected override void Start()
    {
        base.Start();
        API = FindObjectOfType<API>();
    }
    public override void OnClicked(InteractHand interactHand)
    {
        ClickNextButton();
    }
    public void ClickNextButton()
    {
        if (CurrentState == NextButtonState.Start)
        {
            API.OnInvokeNavAction("next");
            NextButtonPressedEvent?.Invoke("next");
        }

        else if (CurrentState == NextButtonState.Fault)
        {
            API.OnInvokeNavAction("start");
            NextButtonPressedEvent?.Invoke("start");
        }
    }
}


