using System;
using TMPro;
using UnityEngine;

public class TimerView : BaseTextObject
{
    [SerializeField] private TextMeshProUGUI _timerText;
    private Timer _timer;
    private void Start()
    {
        _timer = new Timer();
    }
    public override void SetText(string text)
    {
        _timer.TimeChanger(Convert.ToDouble(text));
        _timerText.text = _timer.GetFormattedTime();
    }
}
