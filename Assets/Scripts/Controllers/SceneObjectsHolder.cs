using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class SceneObjectsHolder : MonoBehaviour
{
    public static SceneObjectsHolder Instance;

    [SerializeField] private MovingButtonsController _movingButtonsController;
    [SerializeField] private ShupController _shupController;

    private List<SceneObject> _sceneObjects = new List<SceneObject>();
    private List<MeasureButton> _allMeasureButtons = new List<MeasureButton>();
    private List<SceneActionButton> _sceneActionButtons = new List<SceneActionButton>();
    private List<string> _currentMeasureButtonsNames = new List<string>();
    public bool CanTouch { get; set; } = true;
    private SceneObjectsHolder() { }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void AddSceneObject(SceneObject obj)
    {
        if (obj is PlaceObject)
        {
            var placeObject = (PlaceObject)obj;
            placeObject.SetReactionTransformEvent += OnSetReactionPos;
        }
        else if (obj is SceneObjectWithButton)
        {
            var buttonObject = (SceneObjectWithButton)obj;
            buttonObject.SetButtonsTransformEvent += OnSetMovingButtonsPos;
        }
        else if(obj is MeasureButton)
        {
            var measureButton = (MeasureButton)obj;
            measureButton.MeasurePositionEvent += OnSetShupPosition;
            _allMeasureButtons.Add(measureButton);
        }
        obj.HelperTextEvent += OnShowHelperText;
        _sceneObjects.Add(obj);
    }
    public void AddSceneActionButton(SceneActionButton sceneActionButton)
    {
        _sceneActionButtons.Add(sceneActionButton);
        sceneActionButton.SceneActionButtonEvent += OnAddSceneActionButton;
    }

    public void ActivateSceneObjects(string objectName, string name, string timeText)
    {
        if (timeText == "" || timeText == "0")
            timeText = name;
        else
            timeText = $"{name} \nВремя перехода:{timeText}";
        foreach (var item in _sceneObjects)
        {
            if (item.GetAOSName() == objectName)
            {
                item.EnableObject(true);
                item.SetHelperName(timeText);
            }
        }
    }
    public void DeactivateAllSceneObjects()
    {
        foreach (var sceneObj in _sceneObjects)
            sceneObj.EnableObject(false);
    }

    public void ActivateMeasureButton(string name)
    {
        MeasureButton ButtonToActivate = _allMeasureButtons.FirstOrDefault(n => n.SceneAOSObject.ObjectId == name);
        if (ButtonToActivate != null)
            ButtonToActivate.EnableObject(true);
    }
    public void DeactivateAllMeasureButtons()
    {
        foreach (var item in _allMeasureButtons)
        {
            item.EnableObject(false);
        }
    }
    public void ActivateMeasureButtonsByCurrentList()
    {
        foreach (var item in _currentMeasureButtonsNames)
        {
            ActivateMeasureButton(item);
        }
    }
    public void ResetCurrentMeasureButtonsList()
    {
        _currentMeasureButtonsNames = new List<string>();
    }
    public void AddmeasureButtonToList(string buttonName)
    {
        _currentMeasureButtonsNames.Add(buttonName);
    }
    private void OnSetReactionPos(Transform reactionPos)
    {

    }
    private void OnSetMovingButtonsPos(Transform buttonsPos)
    {
        _movingButtonsController.SetMovingButtonsPosition(buttonsPos.position);
    }
    private void OnShowHelperText(string text)
    {
    }
    private void OnSetShupPosition(Transform pos, string objectId)
    {
        _shupController.SetShupPosition(pos, name);
    }
    private void OnAddSceneActionButton(SceneActionState state)
    {

    }
}
