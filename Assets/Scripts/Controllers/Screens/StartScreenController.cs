using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartScreenController : MonoBehaviour
{

    [SerializeField] private GameObject _menuObject;
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private CursorManager _cursorManager;
    [SerializeField] private TextMeshProUGUI _headerText;
    [SerializeField] private TextMeshProUGUI _commentText;
    [SerializeField] private TextMeshProUGUI _nextButtonText;
    [SerializeField] private NextButton _nextButton;
    [SerializeField] private GameObject _interacthelpers;
    private void OnEnable()
    {
        _nextButton.OnNextButtonPressed += OnHideStartScreen;
    }
    private void OnDisable()
    {
        _nextButton.OnNextButtonPressed -= OnHideStartScreen;
    }
    public void EnableStartScreen(string headerText, string commentText, string buttonText,NextButtonState state)
    {
        _nextButton.gameObject.SetActive(true);
        _startScreen.SetActive(true);
        _headerText.text = headerText;
        _commentText.text = commentText;
        _nextButtonText.text = buttonText;
        _nextButton.CurrentState = state;
        _cursorManager.EnableCursor(true);
        _interacthelpers.SetActive(false);
    }
    private void OnHideStartScreen(string value)
    {
        if(value =="start")
        {
            _menuObject.SetActive(false);
            _startScreen.SetActive(false);
            _cursorManager.EnableCursor(false);
            _interacthelpers.SetActive(true);
            var esc = FindObjectOfType<EscButton>();
            esc.Show = true;
        }
    }
}
