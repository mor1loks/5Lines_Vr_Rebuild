using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class DesktopInteractScreen : BaseInteractScreen
{
    [SerializeField] private GameObject _helper;
    [SerializeField] private GameObject _reaction;
    [SerializeField] private GameObject _timer;
    [SerializeField] private GameObject _location;
    [SerializeField] private GameObject _interactIcons;
    [SerializeField] private BackFromPlaceUIButton _backUIButton;

    [SerializeField] private TextMeshProUGUI _helperText;
    [SerializeField] private TextMeshProUGUI _reactionText;
    [SerializeField] private TextMeshProUGUI _locationText;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private BaseActionObject[] _actionObjects;
    private Vector3 _helperStartPos;
    private Timer _time = new Timer();
    private void Start()
    {
        _helperStartPos = _helper.transform.position;
    }
    public override void SetHelperText(string helperText) => EnableTextObject(helperText, _helperText, _helper);
    public override void SetLocationText(string locationText) => _locationText.text = locationText;
    public override void EnableHelperObject(bool active) => _helper.SetActive(active);
    public override void EnableLocationObject(bool active) => _location.SetActive(true);
    public override void EnableTimerObject(bool active) => _timer.SetActive(true);
    public override void EnableInteractIcons(bool active) => _interactIcons.SetActive(active);
    public override void SetReactionText(string helperText) => _reactionText.text = helperText;
    public override void EnableReactionObject(bool active) => _reaction.SetActive(active);
    public override void SetHelperTextPosition(VectorHolder newPos)
    {
        if (newPos != null)
            _helper.transform.position = newPos.Position;
        else
            _helper.transform.position = _helperStartPos;
    }

    public override void SetTimerText(string timerText)
    {
        double.TryParse(timerText, out double time);
        _time.TimeChanger(time);
        _timerText.text = _time.GetFormattedTime();
    }
    private void EnableTextObject(string text, TextMeshProUGUI textObject, GameObject obj)
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

    public override void EnableActivateActionObject(SceneActionState state)
    {
        if(state == SceneActionState.None)
        {
            foreach (var actionObject in _actionObjects)
            {
                actionObject.CanActivate = false;
                actionObject.ActivateView(false);
                actionObject.Deactivate();
            }
            return;
        }
        var actionObjectToActivate = _actionObjects.FirstOrDefault(o => o.SceneActionState == state);
        if (actionObjectToActivate != null)
        {
            actionObjectToActivate.CanActivate = true;
            actionObjectToActivate.ActivateView(true);
        }
    }
    public override BaseActionObject GetActionObject(SceneActionState state)
    {
        var searchableObject = _actionObjects.FirstOrDefault(o => o.SceneActionState == state);
        if (searchableObject != null)
            return searchableObject;
        return null;
    }
}
