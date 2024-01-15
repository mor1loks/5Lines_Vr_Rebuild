using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasureButtonsNamesSetter : MonoBehaviour
{
    [SerializeField] private MeasureButton[] _mesureButtons;
    [ContextMenu("Init Ids")]
    private void InitButtonsIds()
    {
        foreach (var button in _mesureButtons)
        {
            button.GetComponent<SceneAosObject>().ObjectId = button.name;
        }
    }

}
