using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneActionButtonsHandler : MonoBehaviour
{
    [SerializeField] private CursorManager _cursorManager;
    [SerializeField] private ModeController _modeController;

    private BaseActionObject _actionObject;
    public void EnableActionByState(SceneActionState state)
    {
        if (!SceneObjectsHolder.Instance.CanAction)
            return;
        if(_modeController.DesktopMode)
        _cursorManager.EnableCursor(true);
        switch(state)
        {
            case SceneActionState.Radio:
                _actionObject = _modeController.CurrentRadioObject;
                ActivateObject(_actionObject);
                    break;
            case SceneActionState.Scheme:
                _actionObject = _modeController.CurrentSchemeObject;
                ActivateObject(_actionObject);
                break;
            case SceneActionState.Measure:
                break;
        }    
    }
    private void ActivateObject(BaseActionObject obj)
    {
        if(!obj.Active)
        _actionObject.Activate();
        else
        DisableAction();
    }
    public void DisableAction()
    {
        if (_modeController.DesktopMode && SceneObjectsHolder.Instance.CurrentState == PlayerState.Walk)
            _cursorManager.EnableCursor(false);
        _actionObject.Deactivate();
    }
}
