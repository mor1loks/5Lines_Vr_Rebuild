using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SceneObjectsHolder : MonoBehaviour
{
    public static SceneObjectsHolder Instance;

    private List<SceneObject> _sceneObjects = new List<SceneObject>();
    [SerializeField] private MovingButtonsController _movingButtonsController;

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
        obj.HelperTextEvent += OnShowHelperText;
        _sceneObjects.Add(obj);
    }

    public void ActivateColliders(string objectName, string name, string timeText)
    {
        if (timeText == "" || timeText == "0")
        {
            timeText = name;
        }
        else
        {
            timeText = $"{name} \nВремя перехода:{timeText}";
        }

        foreach (var item in _sceneObjects)
        {
            if (item.GetAOSName() == objectName)
            {
                item.EnableObject(true);

                item.SetHelperName(timeText);
            }
        }
    }
    public void DeactivateAllColliders()
    {
        foreach (var sceneObj in _sceneObjects)
        {
            sceneObj.EnableObject(false);
        }
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
}
