using System;
using TMPro;
using UnityEngine;

public class DesktopInteractScreen : BaseInteractScreen
{
    [SerializeField] private GameObject _helper;
    [SerializeField] private GameObject _reaction;
    [SerializeField] private GameObject _timer;
    [SerializeField] private GameObject _location;
    [SerializeField] private GameObject _actionIcons;
    [SerializeField] private GameObject _interactIcons;
    [SerializeField] private BackFromPlaceUIButton _backUIButton;

    [SerializeField] private TextMeshProUGUI _helperText;
    [SerializeField] private TextMeshProUGUI _reactionText;
    [SerializeField] private TextMeshProUGUI _locationText;
    [SerializeField] private TextMeshProUGUI _timerText;
    private Timer _time = new Timer();
    public override void SetHelperText(string helperText) => EnableTextObject(helperText, _helperText, _helper);
    public override void SetReactionText(string reactionText) => EnableTextObject(reactionText, _reactionText, _reaction);
    public override void SetLocationText(string locationText) => _locationText.text = locationText;
    public override void EnableHelperObject(bool active) => _helper.SetActive(active);
    public override void EnableReactionObject(bool active) => _reaction.SetActive(active);
    public override void EnableLocationObject(bool active) => _location.SetActive(active);
    public override void EnableTimerObject(bool active) => _timer.SetActive(active);
    public override void EnableActionIcons(bool active) => _actionIcons.SetActive(active);
    public override void EnableInteractIcons(bool active) => _interactIcons.SetActive(active);
    public override void SetTimerText(string timerText)
    {
        double.TryParse(timerText, out double time);
        _time.TimeChanger(time);
        _timerText.text = _time.GetFormattedTime();
    }
    private void EnableTextObject(string text, TextMeshProUGUI textObject, GameObject obj)
    {
        Debug.Log(text + " EnableTextObject");
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

    public override void EnableBackButton(bool active)
    {
        _backUIButton.gameObject.SetActive(active);
    }
}
