using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReactionHelper : MonoBehaviour
{
    [SerializeField] private GameObject _reactionHelperObject;
    [SerializeField] private TextMeshProUGUI _reactionText;
    [SerializeField] private API _api;
    private void OnEnable()
    {
        _api.OnReaction += OnShowReactionText;
        _api.OnShowPlace += OnHideReactionText;
        _api.OnEnableMovingButton += OnHideReactionText;
        
    }
    private void OnDisable()
    {
        _api.OnReaction -= OnShowReactionText;
        _api.OnShowPlace -= OnHideReactionText;
        _api.OnEnableMovingButton -= OnHideReactionText;
        
    }
    private void OnShowReactionText(string text)
    {
        _reactionHelperObject.SetActive(true);
        _reactionText.text = HtmlToText.Instance.HTMLToTextReplace(text);
        
    }
    private void OnHideReactionText()
    {
        _reactionHelperObject.SetActive(false);
        _reactionText.text = "";
    }
    private void OnHideReactionText(string temp, string temp2)
    {
        _reactionHelperObject.SetActive(false);
        _reactionText.text = "";
    }

    public void ChangeReactionHelperPosition(Transform newPos)
    {
        transform.position = newPos.position;
    }
    
}
