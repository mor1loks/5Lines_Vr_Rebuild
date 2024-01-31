using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DesktopReactionButtonsHandler : BaseReactionButtonsHandler
{
    [SerializeField] private ReactionUIButton _prefub;
    [SerializeField] private Transform _parent;
    private SceneAosObject _currentAosObject;

    private List<ReactionUIButton> _reactionButtons;
    protected override void Start()
    {
        base.Start();
        _reactionButtons = new List<ReactionUIButton>();
    }
    public override void ShowReactionButtonByName(string buttonActionName, string buttonText)
    {
        Debug.Log(buttonActionName + " ACTION NAME");
        if (string.IsNullOrWhiteSpace(buttonActionName)||ButtonsSpawnPos == null || _currentAosObject == SceneObjectsHolder.Instance.SceneAosObject)
            return;
        _parent.position = ButtonsSpawnPos;
        ButtonActionName reactionName;
        Enum.TryParse<ButtonActionName>(buttonActionName, out reactionName);
        if (ContainsObject(reactionName))
            HideAllReactions();
        _currentAosObject = SceneObjectsHolder.Instance.SceneAosObject;
        var reactionButton = Instantiate(_prefub, _parent);
   
        reactionButton.Init(reactionName, buttonText, _currentAosObject);
        _reactionButtons.Add(reactionButton);
    }
    public override void HideAllReactions()
    {
        foreach (var reactionButton in _reactionButtons)
        {
            if (reactionButton != null)
                Destroy(reactionButton.gameObject);
        }
        _reactionButtons = new List<ReactionUIButton>();
        _currentAosObject = null;
    }
    private bool ContainsObject(ButtonActionName buttonActionName)
    {
        var containsObject = _reactionButtons.SingleOrDefault(b => b.ButtonActionName == buttonActionName);
            if(containsObject != null)
            return true;
        return false;
    }
}
