using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
public enum PlayerState
{
    Walk,
    Look
}

public class SceneObjectsHolder : MonoBehaviour
{
    public static SceneObjectsHolder Instance;

    [SerializeField] private ShupController _shupController;
    [SerializeField] private StrelkaAOS _strelkaAOS;
    [SerializeField] private RadioButtonsContainer _radioButtonsContainer;
    [SerializeField] private LocationController _locationController;
    [SerializeField] private SceneActionButtonsHandler _sceneButtonsHandler;
    [SerializeField] private ModeController _modeController;
    [SerializeField] private CanvasParentChanger _canvasParentChanger;
    [SerializeField] private API _api;
    [SerializeField] private MoveUiButtonsHolder _moveUiButtonsHolder;
    [SerializeField] private MouseRayCastHandler _mouseRayCastHandler;
    public PlayerState CurrentState { get; set; }
    public StrelkaAOS StrelkaAOS => _strelkaAOS;
    public RadioButtonsContainer RadioButtonsContainer => _radioButtonsContainer;
    public LocationController LocationTextController => _locationController;
    public ModeController ModeController => _modeController;
    public MouseRayCastHandler MouseRayCastHandler => _mouseRayCastHandler;

    private List<BaseObject> _baseObjects = new List<BaseObject>();
    private List<BaseUIButton> _baseUiButtons = new List<BaseUIButton>();
    private List<MeasureButton> _allMeasureButtons = new List<MeasureButton>();
    private List<SceneActionButton> _sceneActionButtons = new List<SceneActionButton>();
    private List<string> _currentMeasureButtonsNames = new List<string>();
    private List<ObjectWithAnimation> _objectsWithAnimations = new List<ObjectWithAnimation>();
    public bool CanTouch { get; set; } = true;
    public bool CanAction { get; set; } = true;
    public SceneAosObject SceneAosObject { get; set; }
    private SceneObjectsHolder() { }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Start()
    {
        BackFromPlaceUIButton.ClickBackFromPlaceUiButtonEvent += OnBackUiButtonClick;
        if (_modeController.DesktopMode)
            _mouseRayCastHandler.MousePosHoverEvent += OnChangeHelperOnHoverEvent;
        _mouseRayCastHandler.MousePosClickEvent += OnChangeReactionPositionEvent;
    }
    private void OnHideAllReaction()
    {
        _modeController.BaseReactionButtonsHandler.HideAllReactions();
    }
    private void OnChangeReactionPositionEvent(VectorHolder holder)
    {

        if (holder == null)
            _modeController.BaseReactionButtonsHandler.HideAllReactions();
        else
            _modeController.BaseReactionButtonsHandler.SetButtonSpawnPos(holder.Position);
    }

    private void OnChangeHelperOnHoverEvent(VectorHolder holder)
    {
        _modeController.CurrentInteractScreen.SetHelperTextPosition(holder);
    }

    public void AddSceneObject(BaseObject obj)
    {
        if (obj is PlaceObject)
        {
            var placeObject = (PlaceObject)obj;
            placeObject.CameraChangedEvent += OnChangeCanvasPerent;
            placeObject.AddAnimationObjectEvent += OnAddAnimationObject;
            placeObject.SetBackLocationNameEvent += OnSetBackLocation;
            placeObject.SetSideMovingObjectEvent += OnSetSideMovingObject;

        }
        else if (obj is SceneObjectWithButton)
        {
            var buttonObject = (SceneObjectWithButton)obj;
            buttonObject.SetButtonsTransformEvent += OnSetMovingButtonsPos;
        }
        else if (obj is MeasureButton)
        {
            var measureButton = (MeasureButton)obj;
            measureButton.MeasurePositionEvent += OnSetShupPosition;
            _allMeasureButtons.Add(measureButton);
        }
        if (obj is SceneObject)
        {
            var sceneObject = (SceneObject)obj;
            sceneObject.HelperTextEvent += OnShowHelperText;
        }
        obj.AddSceneObjectEvent += OnInitCurrentSceneObject;
        _baseObjects.Add(obj);
    }
    public void AddBaseUIButton(BaseUIButton obj)
    {
        if(obj is MoveUiButton)
        {
            var moveButton = (MoveUiButton)obj;
            moveButton.PointerEnterEvent += OnHideAllReaction;
        }
        else if(obj is OkUiButton)
        {
            var okButton = (OkUiButton)obj;
            okButton.OkClickEvent += OnHideReactionWindow;
        }
        obj.HoveredUiEvent += OnHandleReactionHover;
        _baseUiButtons.Add(obj);
    }
    private void OnHandleReactionHover(bool active)
    {
        _mouseRayCastHandler.CanHover = !active;
    }
    private void OnHideReactionWindow()
    {
        _modeController.CurrentInteractScreen.EnableReactionObject(false);
        _mouseRayCastHandler.CanHover = true;
    }
    private void OnInitCurrentSceneObject(SceneAosObject sceneAosObject)
    {
        SceneAosObject = sceneAosObject;
    }
    public void AddSceneActionButton(SceneActionButton sceneActionButton)
    {
        _sceneActionButtons.Add(sceneActionButton);
        sceneActionButton.SceneActionButtonEvent += OnActivateSceneAction;
    }
    public void ActivateBaseObjects(string objectName, string name, string timeText)
    {
        if (timeText == "" || timeText == "0")
            timeText = name;
        else
            timeText = $"{name} \nВремя перехода:{timeText}";
        foreach (var item in _baseObjects)
        {
            if (item.GetAOSName() == objectName)
            {
                item.EnableObject(true);
                if (item is SceneObject)
                {
                    var sceneObject = (SceneObject)item;
                    sceneObject.SetHelperName(timeText);
                }
            }
        }
    }
    public void DeactivateAllSceneObjects()
    {
        foreach (var sceneObj in _baseObjects)
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
    public void ActivateMeasureButtonsCurrentList()
    {
        foreach (var item in _currentMeasureButtonsNames)
        {
            ActivateMeasureButton(item);
        }
    }
    public void ResetMeasureButtonsCurrentList()
    {
        _currentMeasureButtonsNames = new List<string>();
    }
    public void AddMeasureButtonToList(string buttonName)
    {
        _currentMeasureButtonsNames.Add(buttonName);
    }
    private void OnSetMovingButtonsPos(Transform buttonsPos)
    {
        //_movingButtonsController.SetMovingButtonsPosition(buttonsPos.position);
    }
    private void OnShowHelperText(string text)
    {
        _modeController.CurrentInteractScreen.SetHelperText(text);
    }
    private void OnSetShupPosition(Transform pos, string objectId)
    {
        _shupController.SetShupPosition(pos, name);
    }
    private void OnActivateSceneAction(SceneActionState state)
    {
        _sceneButtonsHandler.EnableActionByState(state);
    }
    private void OnChangeCanvasPerent(Camera camera)
    {
        _canvasParentChanger.ChangeCameraParent(camera);
    }
    private void OnBackUiButtonClick()
    {
        _canvasParentChanger.RevertCamera();
        _api.InvokeEndTween(_locationController.BackLocation);
        ResetAllAnimationObjects();
        _sceneButtonsHandler.DisableAllObjects();
        _moveUiButtonsHolder.SetSideMovingObject(null);
    }
    private void OnAddAnimationObject(ObjectWithAnimation objectWithAnimation)
    {
        _objectsWithAnimations.Add(objectWithAnimation);
    }
    private void ResetAllAnimationObjects()
    {
        foreach (var animObject in _objectsWithAnimations)
        {
            animObject.PlayScriptableAnimationClose();
        }
        _objectsWithAnimations = new List<ObjectWithAnimation>();
    }
    private void OnSetBackLocation(string location)
    {
        _locationController.BackLocation = location;
    }
    private void OnSetSideMovingObject(BaseSideMovingObject obj)
    {
        _moveUiButtonsHolder.SetSideMovingObject(obj);
        Debug.Log("Side moving object added " + obj.name);
    }
}
