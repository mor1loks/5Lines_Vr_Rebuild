using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingButtonsController : MonoBehaviour
{
    public static MovingButtonsController Instance;
    [HideInInspector] public string ObjectHelperName { get; set; }
    [HideInInspector] public string ObjectName { get; set; }
    private MovingButtonsController() { }
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
    [SerializeField] private API _api;
    [SerializeField] private GameObject _watchButton;
    [SerializeField] private GameObject _repairButton;
    [SerializeField] private GameObject _adjustButton;
    public void ShowButton(string name, string text)
    {
        if (name == "eye")
        {
            _watchButton.SetActive(true);
            SetWatchButtonText(text);
        }
        else if (name == "hand")
        {
            _adjustButton.SetActive(true);
            SetAdjustButtonText(text);
        }
        else if (name == "tool")
        {
            _repairButton.SetActive(true);
            SetRepairButtonText(text);
        }
        
        else if (name == null)
            HideAllButtons();
    }

    public void SetMovingButtonsPosition(Vector3 position)
    {
        transform.position = position;
    }
    public void HideAllButtons()
    {
        _watchButton.SetActive(false);
        _repairButton.SetActive(false);
        _adjustButton.SetActive(false);
    }
    public void SetWatchButtonText(string text)
    {
        _watchButton.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(text);
    }

    public void SetRepairButtonText(string text)
    {
        _repairButton.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(text);
    }
    public void SetAdjustButtonText(string text)
    {
        _adjustButton.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(text);
    }

}
