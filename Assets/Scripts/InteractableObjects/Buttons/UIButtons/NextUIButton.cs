using AosSdk.Core.PlayerModule;
using UnityEngine.UI;

public class NextUIButton : NextButton
{
    private Button _button;
    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => OnClick());
    }
    public void OnClick()
    {
        if (CurrentState == NextButtonState.Start)
        {
            API.OnInvokeNavAction("next");
            OnNextButtonPressed?.Invoke("next");
            Player.Instance.CanMove = false;
        }
        else if (CurrentState == NextButtonState.Fault)
        {
            API.OnInvokeNavAction("start");
            OnNextButtonPressed?.Invoke("start");
            Player.Instance.CanMove = true;
        }
    }
}
