using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartScreenController : MonoBehaviour
{
    [SerializeField] private API _api;
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private TextMeshProUGUI _headerText;
    [SerializeField] private TextMeshProUGUI _commentText;
    [SerializeField] private TextMeshProUGUI _nextButtonText;
    [SerializeField] private NextButton _nextButton;
    private void OnEnable()
    {
        _api.OnSetStartText += OnEnableStartScreen;
        _nextButton.OnNextButtonPressed += OnHideStartScreen;
    }
    private void OnDisable()
    {
        _api.OnSetStartText -= OnEnableStartScreen;
        _nextButton.OnNextButtonPressed -= OnHideStartScreen;
    }
    private void OnEnableStartScreen(string headerText, string commentText, string buttonText,NextButtonState state)
    {
        _startScreen.SetActive(true);
        _headerText.text = headerText;
        _commentText.text = commentText;
        _nextButtonText.text = buttonText;
        _nextButton.CurrentState = state;
    }
    private void OnHideStartScreen(string value)
    {
        if(value =="start")
            _startScreen.SetActive(false);
    }

}
