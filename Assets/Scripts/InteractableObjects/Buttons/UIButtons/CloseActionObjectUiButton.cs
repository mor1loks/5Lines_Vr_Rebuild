using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseActionObjectUiButton : BaseUIButton
{
    private SceneActionButtonsHandler _sceneObjectHandler;
    protected override void Click()
    {
       _sceneObjectHandler = FindObjectOfType<SceneActionButtonsHandler>();
        if (_sceneObjectHandler != null)
            _sceneObjectHandler.DisableAction();
    }
}
