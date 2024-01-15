using TMPro;
using UnityEngine;

public class DesktopMenuScreen : BaseMenuScreen
{
    [SerializeField] private TextMeshProUGUI _infoHeaderText;
    [SerializeField] private TextMeshProUGUI _infoText;
    [SerializeField] private TextMeshProUGUI _exitSureText;
    [SerializeField] private TextMeshProUGUI _exitText;
    [SerializeField] private TextMeshProUGUI _warnText;


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
    public override void SetMenuText(string headText, string commentText, string exitSureText)
    {
        Debug.Log($"head text {headText} comment text {commentText} exit sure text{exitSureText}");
        _infoHeaderText.text = HtmlToText.Instance.HTMLToTextReplace(headText);
        _infoText.text = HtmlToText.Instance.HTMLToTextReplace(commentText);
        _exitSureText.text = HtmlToText.Instance.HTMLToTextReplace(exitSureText);
    }

    public override void SetExitText(string exitText, string warntext)
    {
        _exitText.text = HtmlToText.Instance.HTMLToTextReplace(exitText);
        _warnText.text = HtmlToText.Instance.HTMLToTextReplace(warntext);
    }

    public override void ShowMessageScreen(string headText, string commentText)
    {
        _desktopCanvasHolder.DisableAllCanvases();
        _desktopCanvasHolder.EnableCanvasByState(CanvasState.Last);
        ShowMessageScreen();
        SetText(headText, commentText);
    }

    public override void ShowLastScteen(string headText, string commentText, string evaltext)
    {
        ShowLastScreen();
        SetText(headText, commentText, evaltext);
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
