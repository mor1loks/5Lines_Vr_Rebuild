using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DesktopMenuScreen : BaseMenuScreen
{
    

    [SerializeField] private Text _infoHeaderText;
    [SerializeField] private Text _infoText;
    [SerializeField] private Text _exitSureText;
    [SerializeField] private Text _exitText;
    [SerializeField] private Text _headMessageText;
    [SerializeField] private Text _commentMessageText;
    [SerializeField] private Text _footerMessageText;
    [SerializeField] private Text _warnText;   
    [Space]
    [SerializeField] private DesktopCanvasHolder _desktopCanvasHolder;  
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _exitButton;
    [SerializeField] private GameObject _backButton;
    [SerializeField] private AlarmImageController _armImageController;

    public override void SetMenuText(string headText, string commentText, string exitSureText)
    {
        _infoHeaderText.text = HtmlToText.Instance.HTMLToTextReplace(headText);
        _infoText.text = HtmlToText.Instance.HTMLToTextReplace(commentText);
        _exitText.text = HtmlToText.Instance.HTMLToTextReplace(exitSureText);
    }
    public override void SetExitText(string exitText, string warnText)
    {
       
        _exitSureText.text = HtmlToText.Instance.HTMLToTextReplace(exitText);
        _warnText.text = HtmlToText.Instance.HTMLToTextReplace(warnText);
    }
    public override void ShowMessageScreen(string headText, string commentText,string footerText,string alarmImg)
    {
        _desktopCanvasHolder.DisableAllCanvases();
        _desktopCanvasHolder.EnableCanvasByState(CanvasState.Last);
        ShowMessageScreen();
        SetMessageText(headText, commentText, footerText,alarmImg);
    }
    public override void ShowLastScreen(string headText, string commentText, string evalText)
    {
        _desktopCanvasHolder.DisableAllCanvases();
        _desktopCanvasHolder.EnableCanvasByState(CanvasState.MainMenu);
        _desktopCanvasHolder.EnableCanvasByState(CanvasState.Last);
        _backButton.SetActive(false);
        _exitButton.SetActive(true);
       // SetText(headText, commentText, evalText);
    }
   
    private void SetText(string headText, string commentText, string evalText)
    {
       
    }
    private void SetMessageText(string headText, string commentText, string footerText, string alarmImg)
    {
        _headMessageText.text = headText;
        _commentMessageText.text = commentText;
        _footerMessageText.text = footerText;
        _armImageController.SetAlarmImage(alarmImg);



    }
    private void ShowMessageScreen()
    {
        _desktopCanvasHolder.EnableCanvasByState(CanvasState.Last);
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
