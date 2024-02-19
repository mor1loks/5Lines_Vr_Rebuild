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
    [SerializeField] private Text _headResutText;   
    [SerializeField] private Text _evalResultText;   
    [SerializeField] private Text _commentResultText;   
    [Space]
    [SerializeField] private DesktopCanvasHolder _desktopCanvasHolder;  
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _hideBackButton;
    [SerializeField] private GameObject _showBackButton;
    [SerializeField] private GameObject _resultPanel;
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
        _resultPanel.SetActive(true);
        _showBackButton.SetActive(true);   
        _hideBackButton.SetActive(false);
        SetResultText(headText, commentText, evalText);
    }
   
    private void SetResultText(string headText, string commentText, string evalText)
    {
        _headResutText.text = headText;
        _evalResultText.text = evalText;
        _commentResultText.text = commentText;


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
