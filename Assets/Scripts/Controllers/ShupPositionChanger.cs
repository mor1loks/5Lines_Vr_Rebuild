using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShupPositionChanger : MonoBehaviour
{
    public static ShupPositionChanger Instance;
    [SerializeField] private ShupController _shupController;
    [SerializeField] private List <MeasureButton> _measureButtons;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void SetNewShupPositon(Transform pos, string name)
    {
        _shupController.SetShupPosition(pos, name);
    }
}
