using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeasureButtonsActivator : MonoBehaviour
{
    public static MeasureButtonsActivator Instance;

    private List<string> _currentButtonsNames = new List<string>();
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void ActivateMeasureButton(string name)
    {

    }
    public void DeactivateAllButtons()
    {

    }
    public void ActivateButtonsWithList()
    {
        foreach (var item in _currentButtonsNames)
        {
            ActivateMeasureButton(item);
        }
    }
    public void ResetCurrentButtonsList()
    {
        _currentButtonsNames = new List<string>();
    }
    public void AddButtonToList(string buttonName)
    {
        _currentButtonsNames.Add(buttonName);
    }    

}
