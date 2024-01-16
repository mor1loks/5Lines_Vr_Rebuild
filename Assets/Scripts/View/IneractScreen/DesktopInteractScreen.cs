using TMPro;
using UnityEngine;

public class DesktopInteractScreen : BaseInteractScreen
{
    [SerializeField] private GameObject _helper;
    [SerializeField] private GameObject _reaction;
    [SerializeField] private GameObject _timer;
    [SerializeField] private GameObject _location;

    [SerializeField] private TextMeshProUGUI _helperText;
    [SerializeField] private TextMeshProUGUI _reactionText;
    [SerializeField] private TextMeshProUGUI _locationText;
    [SerializeField] private TextMeshProUGUI _timerText;
    public override void SetHelperText(string helperText) => EnableTextObject(helperText, _helperText,_helper);
    public override void SetReactionText(string reactionText) => EnableTextObject(reactionText, _reactionText,_reaction);
    public override void SetLocationText(string locationText) => _locationText.text = locationText;
    public override void SetTimerText(string timerText) => _timerText.text = timerText;
    private void EnableTextObject(string text, TextMeshProUGUI textObject,GameObject obj)
    {
        if (text == null)
        {
            obj.SetActive(false);
            textObject.text = "";
        }
        else
        {
            textObject.text = text;
            obj.SetActive(true);
        }
    }
    public void EnableHelperObject(bool active) => _helper.SetActive(active);
    public void EnableReactionObject(bool active) => _reaction.SetActive(active);
    public void EnableLocationObject(bool active) => _location.SetActive(active);
    public void EnableTimerObject(bool active) => _timer.SetActive(active);
}
