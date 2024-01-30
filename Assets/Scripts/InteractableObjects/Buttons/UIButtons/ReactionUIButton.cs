using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReactionUIButton :BaseUIButton
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _currentSprite;
    [SerializeField] private TextMeshProUGUI _reactionText;

    private ButtonActionName _currentActionName;
    private StringParser _stringParser;
    private SceneAosObject _sceneAosObject;
    private void Start()
    {
        _stringParser = new StringParser();
    }
    public void Init(ButtonActionName buttonActionName, string text, SceneAosObject sceneAosObject)
    {
        _currentActionName = buttonActionName;
        var sprite = GetSpriteByName();
        if (sprite != null)
            _currentSprite.sprite = sprite;
        _reactionText.text = text;
        _sceneAosObject = sceneAosObject;
    }
    protected override void Click()
    {
        if (_sceneAosObject == null)
            return;
        var actionText = _stringParser.GetStringFromEnum(_currentActionName);
        _sceneAosObject.ActionWithObject(actionText);
    }
    private Sprite GetSpriteByName()
    {
        foreach (var sprite in _sprites)
        {
            if(sprite.name==_stringParser.GetStringFromEnum(_currentActionName))
                return sprite;
        }
        return null;
    }
}
