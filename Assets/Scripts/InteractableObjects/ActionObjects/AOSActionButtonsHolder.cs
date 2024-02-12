using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AOSActionButtonsHolder : MonoBehaviour
{
    [SerializeField] private SceneAosObject[] _radioAOSButtons;
    [SerializeField] private SceneAosObject[] _schemeAOSButtons;
    [SerializeField] private SceneAosObject[] _measureAOSButtons;

    private SceneAosObject _currentRadioButton;
    private SceneAosObject _currentSchemeButton;
    private SceneAosObject _currentMeasureButton;
    public void SetCurrentRadioButton(string name)
    {
        var currentRadio = SearchObject(_radioAOSButtons, name);
        if (currentRadio != null)
            _currentRadioButton = currentRadio;
    }
    public void SetCurrentSchemeButton(string name)
    {
        var currentScheme = SearchObject(_schemeAOSButtons, name);
        if (currentScheme != null)
            _currentSchemeButton = currentScheme;
    }
    public void SetCurrentMeasureButton(string name)
    {
        var currentMeasure = SearchObject(_measureAOSButtons, name);
        if (currentMeasure != null)
            _currentMeasureButton = currentMeasure;
    }
    private SceneAosObject SearchObject(SceneAosObject[] sceneObjects, string name)
    {
        var searchingObject = sceneObjects.FirstOrDefault(x => x.ObjectId == name);
        if (searchingObject != null)
            return searchingObject;
        return null;
    }
    public void InVokeOnClick(SceneActionState state)
    {
        switch(state)
        {
            case SceneActionState.Radio:
                if (_currentRadioButton != null)
                    _currentRadioButton.InvokeOnClick();
                    break;
            case SceneActionState.Scheme:
                if (_currentSchemeButton != null)
                    _currentSchemeButton.InvokeOnClick();
                break;
            case SceneActionState.Measure:
                if (_currentMeasureButton != null)
                    _currentMeasureButton.InvokeOnClick();
                break;
        }
    }

}
