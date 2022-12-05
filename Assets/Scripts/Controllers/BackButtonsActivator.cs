using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonsActivator : MonoBehaviour
{
    public static BackButtonsActivator Instance;
    [SerializeField] private API _api;
    private BackButtonObject _currentBackButton;
    private void OnEnable()
    {
        _api.OnActivateBackButton += OnActivaBackButton;
    }
    private void OnDisable()
    {
        _api.OnActivateBackButton -= OnActivaBackButton;
    }
    private void OnActivaBackButton(string text)
    {
        ActionToInvoke = text;
        EnableCurrentBackButton(true);
    }
    public string ActionToInvoke { get; set; }
    private void Awake()
    {
        if(Instance ==null)
        Instance = this;
    }
    public void SetBackButtonObject(BackButtonObject backButtonObject)
    {
        _currentBackButton = backButtonObject;
    }
    public BackButtonObject GetCurrentBackButton()
    {
        if(_currentBackButton!=null)
        return _currentBackButton;
        else return null;
    }
    public void EnableCurrentBackButton(bool value)
    {
        if(_currentBackButton!=null)
        _currentBackButton.EnableButton(value);
    }

}
