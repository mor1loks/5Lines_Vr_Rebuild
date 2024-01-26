using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUIWithActionPerform : BaseUIButton
{
    [SerializeField] private SceneActionButton _actionButton;

    protected override void Click() => _actionButton.InvokeActionEvent();
}
