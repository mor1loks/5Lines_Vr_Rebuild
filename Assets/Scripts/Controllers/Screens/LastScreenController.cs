using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LastScreenController : MonoBehaviour
{
    [SerializeField] private MainMenuController _mainMenuController;
    [SerializeField] private GameObject _lastScreen;
    [SerializeField] private GameObject _exitPanel;
    [SerializeField] private GameObject _otkaziPerevod;
    [SerializeField] private GameObject _otkaziSep;
    [SerializeField] private GameObject _otkaziRelay;
    [SerializeField] private GameObject _otkaziMyfta;
    [SerializeField] private TextMeshProUGUI _headerText;
    [SerializeField] private TextMeshProUGUI _evalText;
    [SerializeField] private TextMeshProUGUI _commentText;
    [SerializeField] private GameObject _exitButton;
    [SerializeField] private GameObject _backButton;
    [SerializeField] private DesktopCanvasHolder _desktopCanvasHolder;
    public void ShowMessageScreen(string headText, string commentText)
    {
        _desktopCanvasHolder.DisableAllCanvases();
        _desktopCanvasHolder.EnableCanvasByState(CanvasState.Last);
        ShowMessageScreen();
      SetText(headText, commentText);
    }
    public void ShowLastScteen(string headText, string commentText, string evaltext)
    {
        ShowLastScreen();
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
        _lastScreen.SetActive(true);
    }

    public void ShowLastScreen()
    {
        _mainMenuController.AllowTeleport(false);
        _exitPanel.SetActive(false);
        _backButton.SetActive(false);
        _otkaziPerevod.SetActive(false);
        _otkaziSep.SetActive(false);
        _otkaziRelay.SetActive(false);
        _otkaziMyfta.SetActive(false);
        _lastScreen.SetActive(true);
        _exitButton.SetActive(true);
    }
}
