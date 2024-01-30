using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopReactionButtonsHandler : BaseReactionButtonsHandler
{
    [SerializeField] private ReactionUIButton _prefub;
    [SerializeField] private Transform _parent;

    private List<ReactionUIButton> _reactionButtons;
    protected override void Start()
    {
        base.Start();
        _reactionButtons = new List<ReactionUIButton>();
    }
    public override void ShowReactionButtonByName(string buttonActionName, string buttonText)
    {
        if (string.IsNullOrWhiteSpace(buttonActionName))
            return;
        //if (ButtonsSpawnPos == null)
        //    return;
        //transform.position = ButtonsSpawnPos.transform.position;
        Debug.Log("Button name " + buttonActionName + " Button Text " + buttonText);
        var currentSceneObject = SceneObjectsHolder.Instance.SceneAosObject;
        var reactionButton = Instantiate(_prefub, _parent);
        ButtonActionName reactionName;
        Enum.TryParse<ButtonActionName>(buttonActionName, out reactionName);
        reactionButton.Init(reactionName, buttonText, currentSceneObject);
        _reactionButtons.Add(reactionButton);
    }
    public override void HideAllReactions()
    {
        if (_reactionButtons == null || _reactionButtons.Count < 1)
            return;
        foreach (var reactionButton in _reactionButtons)
        {
            if (reactionButton != null)
                Destroy(reactionButton);
        }
        _reactionButtons = new List<ReactionUIButton>();
    }
}
