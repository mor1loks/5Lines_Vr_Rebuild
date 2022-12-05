using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuTextView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _infoHeaderText;
    [SerializeField] private TextMeshProUGUI _infoText;
    [SerializeField] private TextMeshProUGUI _exitSureText;
    [SerializeField] private TextMeshProUGUI _exitText;
    [SerializeField] private TextMeshProUGUI _warnText;
    [SerializeField] private API _api;
    private void OnEnable()
    {
        _api.OnShowMenuText += OnSetMenuText;
        _api.OnShowExitText += OnSetExitText;
    }
    private void OnDisable()
    {
        _api.OnShowMenuText -= OnSetMenuText;
        _api.OnShowExitText -= OnSetExitText;
    }
    private void OnSetMenuText(string headText, string commentText, string exitSureText)
    {
        _infoHeaderText.text = headText;
        _infoText.text = commentText;
        _exitSureText.text = exitSureText;
    }

    private void OnSetExitText(string exitText, string warntext)
    {
        _exitText.text = exitText;
        _warnText.text = warntext;
    }
 
}
