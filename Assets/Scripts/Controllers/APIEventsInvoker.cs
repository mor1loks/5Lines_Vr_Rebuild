using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIEventsInvoker : MonoBehaviour
{
    [SerializeField] private API _api;
    [SerializeField] private ConnectionToClient _connection;
    [SerializeField] private Teleporter _teleporter;
    [SerializeField] private LocationController _locationController;
    [SerializeField] private Diet _diet;
    [SerializeField] private ModeController _modeController;
    [SerializeField] private MeasureController _measureController;

    private void OnEnable()
    {
        _connection.ConnectionReadyEvent += OnSetLocationAfterConnection;
        _api.ShowPlaceEvent += OnDeactivateCollidersInStart;
        _api.ResetMeasureButtonsEvent += OnResetMeasureButtons;
        _api.SetTeleportLocationEvent += OnSetLocationToTeleport;
        _api.SetNewLocationTextEvent += OnSetLocationTextToLocationController;
        _api.SetLocationEvent += OnSetLocationToLocationController;
        _api.EnableDietButtonsEvent += OnEnableDietButton;
        _api.EnableRactionButtonEvent += OnEnableReactionButton;
        _api.ReactionEvent+=OnSetReaction;
        _api.SetTimerTextEvent+= OnSetTimerText;
        _api.AddMeasureButtonEvent += OnAddButtonToMeasureButtonsList;
        _api.ActivateByNameEvent += OnActivateSceneObjectByName;
        _api.SetMessageTextEvent += OnSetLastScreenText;
        _api.SetResultTextEvent += OnSetResultScreenText;
        _api.ShowExitTextEvent += OnSetExitText;
        _api.ShowMenuTextEvent += OnSetMenuText;
        _api.SetStartTextEvent+= OnSetStartText;
        _api.SetMeasureValueEvent += OnSetMeasureValue;

    }

    private void OnDisable()
    {
        _connection.ConnectionReadyEvent -= OnSetLocationAfterConnection;
        _api.ShowPlaceEvent -= OnDeactivateCollidersInStart;
        _api.ResetMeasureButtonsEvent -= OnResetMeasureButtons;
        _api.SetTeleportLocationEvent -= OnSetLocationToTeleport;
        _api.SetNewLocationTextEvent -= OnSetLocationTextToLocationController;
        _api.SetLocationEvent -= OnSetLocationToLocationController;
        _api.EnableDietButtonsEvent -= OnEnableDietButton;
        _api.EnableRactionButtonEvent -= OnEnableReactionButton;
        _api.ReactionEvent -= OnSetReaction;
        _api.SetTimerTextEvent -= OnSetTimerText;
        _api.AddMeasureButtonEvent -= OnAddButtonToMeasureButtonsList;
        _api.ActivateByNameEvent -= OnActivateSceneObjectByName;
        _api.SetMessageTextEvent -= OnSetLastScreenText;
        _api.SetResultTextEvent -= OnSetResultScreenText;
        _api.ShowExitTextEvent -= OnSetExitText;
        _api.ShowMenuTextEvent -= OnSetMenuText;
        _api.SetStartTextEvent -= OnSetStartText;
        _api.SetMeasureValueEvent -= OnSetMeasureValue;

    }
    private void OnDeactivateCollidersInStart()
    {
        SceneObjectsHolder.Instance.DeactivateAllSceneObjects();
    }
    private void OnResetMeasureButtons()
    {
        SceneObjectsHolder.Instance.ResetMeasureButtonsCurrentList();
    }
    private void OnSetReaction(string text)
    {
        SceneObjectsHolder.Instance.ModeController.CurrentInteractScreen.EnableReactionObject(true);
        SceneObjectsHolder.Instance.ModeController.CurrentInteractScreen.SetReactionText(text);
        SceneObjectsHolder.Instance.ModeController.CurrentInteractScreen.EnableHelperObject(false);
        SceneObjectsHolder.Instance.ModeController.BaseReactionButtonsHandler.HideAllReactions();
        SceneObjectsHolder.Instance.MouseRayCastHandler.CanInteract = false;
    }
    private void OnSetLocationToTeleport(string location)
    {
        _teleporter.Teleport(location);
    }
    private void OnSetLocationTextToLocationController(string location)
    {
        _modeController.CurrentInteractScreen.SetLocationText(location);
    }
    private void OnSetLocationToLocationController(string location)
    {
        _locationController.SetLocation(location);
    }
    private void OnSetLocationAfterConnection()
    {
        _locationController.ConnectionEstablished();
    }
    private void OnEnableDietButton(string buttonName)
    {
        Debug.Log(buttonName + "Radio");
        _diet.EnablePlusOrMinus(buttonName);
    }
    private void OnEnableReactionButton(string button,string buttonName)
    {
        _modeController.BaseReactionButtonsHandler.ShowReactionButtonByName(button, buttonName);
    }
    private void OnSetTimerText(string timerText)
    {
      _modeController.CurrentInteractScreen.SetTimerText(timerText);
    }
    private void OnAddButtonToMeasureButtonsList(string buttonName)
    {
        SceneObjectsHolder.Instance.AddMeasureButtonToList(buttonName);
    }
    private void OnActivateSceneObjectByName(string id, string name, string time)
    {
        SceneObjectsHolder.Instance.ActivateBaseObjects(id, name,time);
    }
    private void OnSetLastScreenText(string headerText, string commentText)
    {
        _modeController.CurrentMenuScreen.ShowMessageScreen(headerText, commentText);
    }
    private void OnSetResultScreenText(string headerText, string commentText, string evalText)
    {
        _modeController.CurrentMenuScreen.ShowLastScreen(headerText, commentText, evalText);
        _modeController.CurrentMenuController.TeleportByGameTimer();
    }
    private void OnSetExitText(string exitText, string warnText)
    {
      _modeController.CurrentMenuScreen.SetExitText(exitText, warnText);
    }
    private void OnSetMenuText(string headText, string commentText, string exitSureText)
    {
        _modeController.CurrentMenuScreen.SetMenuText(headText, commentText, exitSureText);
    }
    private void OnSetStartText(string headerText, string commentText, string buttonText, NextButtonState state)
    {
        _modeController.CurrentStartScreen.SetStartScreenText(headerText, HtmlToText.Instance.HTMLToTextReplace(commentText), buttonText, state);
    }
    private void OnSetMeasureValue(float value)
    {
        _measureController.SetDeviceValue(value);
    }

}
