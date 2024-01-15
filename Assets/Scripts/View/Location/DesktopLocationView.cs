using TMPro;
using UnityEngine;
public class DesktopLocationView : BaseTextObject
{
    [SerializeField] private TextMeshProUGUI _deskLocationText;
    public override void SetText(string text)
    {
        _deskLocationText.text = text;
    }
}
