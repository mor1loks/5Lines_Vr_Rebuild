using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackUIbuttonResult : BaseUIButton
{
    public static Action BackButtonClickEvent;
    [SerializeField] private bool _event;
    [SerializeField] private GameObject _messagePanel;
    protected override void Click()
    {
        if (_event)
        {
            API.OnInvokeNavAction("back");
        }

        BackButtonClickEvent?.Invoke();
        
        if (_messagePanel != null)
        {
            _messagePanel.SetActive(false);
        }
    }
}
    

