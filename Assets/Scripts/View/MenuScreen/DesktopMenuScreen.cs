using TMPro;
using UnityEngine;

public class DesktopMenuScreen : BaseMenuScreen
{
    [SerializeField] private TextMeshProUGUI _infoHeaderText;
    [SerializeField] private TextMeshProUGUI _infoText;
    [SerializeField] private TextMeshProUGUI _exitSureText;
    [SerializeField] private TextMeshProUGUI _exitText;
    [SerializeField] private TextMeshProUGUI _warnText;
    [SerializeField] private TextMeshProUGUI _headerText;
    [SerializeField] private TextMeshProUGUI _evalText;
    [SerializeField] private TextMeshProUGUI _commentText;
    [Space]
    [SerializeField] private DesktopCanvasHolder _desktopCanvasHolder;
    [SerializeField] private AlarmImageController _armImageController;
    [SerializeField] private GameObject[] _allScreens;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _exitButton;
    [SerializeField] private GameObject _backButton;
    [SerializeField] private GameObject _messagePanel;
    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private GameObject _toResultPanel;
    [SerializeField] private GameObject _hideBackButton;


    public override void SetMenuText(string headText, string commentText, string exitSureText)
    {
        Debug.Log($"head text {headText} comment text {commentText} exit sure text{exitSureText}");
        _infoHeaderText.text = HtmlToText.Instance.HTMLToTextReplace(headText);
        _infoText.text = HtmlToText.Instance.HTMLToTextReplace(commentText);
        _exitSureText.text = HtmlToText.Instance.HTMLToTextReplace(exitSureText);
    }
    public override void SetExitText(string exitText, string warnText)
    {
        _exitText.text = HtmlToText.Instance.HTMLToTextReplace(exitText);
        _warnText.text = HtmlToText.Instance.HTMLToTextReplace(warnText);
    }
    public override void ShowMessageScreen(string headText, string commentText, string footerText, string alarmImg)
    {
        _desktopCanvasHolder.DisableAllCanvases();
        _desktopCanvasHolder.EnableCanvasByState(CanvasState.MainMenu);
        ShowMessageScreen();
        SetText(headText, commentText, footerText);
        _armImageController.SetAlarmImage(alarmImg);
    }
    public override void ShowLastScreen(string headText, string commentText, string evalText)
    {
        var _menuController = FindObjectOfType<BaseMenuController>();
        _menuController.CanTeleport = false;
        _desktopCanvasHolder.DisableAllCanvases();

        _desktopCanvasHolder.EnableCanvasByState(CanvasState.MainMenu);
        _desktopCanvasHolder.EnableCanvasByState(CanvasState.Menu);
        _resultPanel.SetActive(true);
        _backButton.SetActive(false);
        _exitButton.SetActive(true);
        _toResultPanel.SetActive(true);
        _hideBackButton.SetActive(false);

        _desktopCanvasHolder.EnableCanvasByState(CanvasState.Result);
        SetResultText(headText, commentText, evalText);

    }

    private void SetText(string headText, string commentText, string evalText)
    {
        _headerText.text = headText;
        _commentText.text = commentText;
        _evalText.text = evalText;
    }
    private void SetResultText(string headText, string commentText, string evalText)
    {
    }
    private void ShowMessageScreen()
    {
        _desktopCanvasHolder.EnableCanvasByState(CanvasState.Menu);
        _messagePanel.SetActive(true);
    }

    public override void ShowMenuScreen(bool active)
    {
        _desktopCanvasHolder.DisableAllCanvases();
        _menu.SetActive(active);
        if (active)
        {
            _desktopCanvasHolder.EnableCanvasByState(CanvasState.MainMenu);
            _desktopCanvasHolder.EnableCanvasByState(CanvasState.Menu);
        }
    }
}
