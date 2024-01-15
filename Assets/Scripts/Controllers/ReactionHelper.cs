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
        _api.ReactionEvent += OnShowReactionText;
        _api.ShowPlaceEvent += OnHideReactionText;
        _api.EnableMovingButtonEvent += OnHideReactionText;
        
    }
    private void OnDisable()
    {
        _api.ReactionEvent -= OnShowReactionText;
        _api.ShowPlaceEvent -= OnHideReactionText;
        _api.EnableMovingButtonEvent -= OnHideReactionText;
        
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
