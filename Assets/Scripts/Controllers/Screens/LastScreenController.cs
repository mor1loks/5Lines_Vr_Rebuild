using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LastScreenController : MonoBehaviour
{
    [SerializeField] private GameObject[] _screens;
    [SerializeField] private MainMenuController _mainMenuController;
    [SerializeField] private GameObject _lastScreen;
    [SerializeField] private TextMeshProUGUI _headerText;
    [SerializeField] private TextMeshProUGUI _commentText;
    [SerializeField] private GameObject _exitButton;
    [SerializeField] private GameObject _backButton;
    [SerializeField] private API _api;
    private void OnEnable()
    {
        _api.OnSetMessageText += OnShowMessageScreen;
        _api.OnSetResultext += OnShowLastScteen;
    }
    private void OnDisable()
    {
        _api.OnSetMessageText -= OnShowMessageScreen;
        _api.OnSetResultext -= OnShowLastScteen;
    }
    private void OnShowMessageScreen(string headText, string commentText)
    {
        ShowMessageScreen();
      SetText(headText, commentText);
    }
    private void OnShowLastScteen(string headText, string commentText)
    {
        ShowLastScreen();
        SetText(headText, commentText);
    }
    private void SetText(string headText, string commentText)
    {
        _headerText.text = headText;
        _commentText.text = commentText;
    }

    private void ShowMessageScreen()
    {

        foreach (var item in _screens)
        {
            item.SetActive(false);
        }
        _lastScreen.SetActive(true);
    }

    public void ShowLastScreen()
    {
        _mainMenuController.AllowTeleport(false);
        foreach (var item in _screens)
        {
            item.SetActive(false);
        }
        _backButton.SetActive(false);
        _lastScreen.SetActive(true);
        _exitButton.SetActive(true);
    }
}
