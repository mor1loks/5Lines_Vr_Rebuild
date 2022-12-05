using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeasureButtonsActivator : MonoBehaviour
{
    public static MeasureButtonsActivator Instance;
    [SerializeField] private MeasureAosButton[] _measureButtons;
    [SerializeField] private API _api;
    private List<string> _currentButtonsNames = new List<string>();
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void OnEnable()
    {
        _api.OnResetMeasureButtons += OnResetCurrentButtonsList;
        _api.OnAddMeasureButton += OnAddButtonToList;
    }
    private void OnDisable()
    {
        _api.OnResetMeasureButtons -= OnResetCurrentButtonsList;
        _api.OnAddMeasureButton -= OnAddButtonToList;
    }

    public void ActivateMeasureButton(string name)
    {
        MeasureAosButton tempButton = _measureButtons.FirstOrDefault(n => n.ObjectId == name);
        if (tempButton != null)
            tempButton.ActivateMeasureButton(true);
    }
    public void DeactivateAllButtons()
    {
        foreach (var item in _measureButtons)
        {
            item.ActivateMeasureButton(false);
        }
    }
    public void ActivateButtonsWithList()
    {
        foreach (var item in _currentButtonsNames)
        {
            ActivateMeasureButton(item);
        }
    }
    private void OnResetCurrentButtonsList()
    {
        _currentButtonsNames = new List<string>();
    }
    private void OnAddButtonToList(string buttonName)
    {
        _currentButtonsNames.Add(buttonName);
    }    

}
