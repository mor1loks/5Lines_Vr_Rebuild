using TMPro;
using UnityEngine;

public class DesktopInteractScreen : BaseInteractScreen
{
    [SerializeField] private TextMeshProUGUI _helperText;
    [SerializeField] private TextMeshProUGUI _reactionText;
    [SerializeField] private TextMeshProUGUI _locationText;
    [SerializeField] private TextMeshProUGUI _timerText;
    public override void SetHelperText(string helperText) => EnableTextObject(helperText, _helperText);
    public override void SetReactionText(string reactionText) => EnableTextObject(reactionText, _reactionText);
    public override void SetLocationText(string locationText) => _locationText.text = locationText;
    public override void SetTimerText(string timerText) => _timerText.text = timerText;
    private void EnableTextObject(string text, TextMeshProUGUI textObject)
    {
        if (text == null)
        {
            textObject.gameObject.SetActive(false);
            textObject.text = "";
        }
        else
        {
            textObject.text = text;
            textObject.gameObject.SetActive(true);
        }
    }
    public void EnableHelperObject(bool active) => _helperText.gameObject.SetActive(active);
    public void EnableReactionObject(bool active) => _reactionText.gameObject.SetActive(active);
    public void EnableLocationObject(bool active) => _locationText.gameObject.SetActive(active);
    public void EnableTimerObject(bool active) => _timerText.gameObject.SetActive(active);
}
