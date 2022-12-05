using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "Начальный экран")]

public class StartScreen : AosObjectBase
{
    [SerializeField] private TextMeshProUGUI _commentText;
    public void SetStartScreen(string value)
    {
        _commentText.text = value;
    }
}
