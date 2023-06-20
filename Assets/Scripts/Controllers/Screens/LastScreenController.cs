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
    [SerializeField] private TextMeshProUGUI _evalText;
    [SerializeField] private TextMeshProUGUI _commentText;
    [SerializeField] private GameObject _exitButton;
    [SerializeField] private GameObject _backButton;
    [SerializeField] private GameObject _locationName;
    public void ShowMessageScreen(string headText, string commentText)
    {
        ShowMessageScreen();
      SetText(headText, commentText);
    }
    public void ShowLastScteen(string headText, string commentText, string evaltext)
    {
        ShowLastScreen();
        _locationName.SetActive(false);
        SetText(headText, commentText,evaltext);
    }
    private void SetText(string headText, string commentText)
    {
        _headerText.text = headText;
        _commentText.text = commentText;
    }
    private void SetText(string headText, string commentText, string evalText)
    {
        _headerText.text = headText;
        _commentText.text = commentText;
        _evalText.text = evalText;
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
