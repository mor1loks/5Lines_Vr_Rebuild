using System.Collections.Generic;
using System.Linq;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using UnityEngine;
[RequireComponent(typeof(Collider))]

public class TriggerObject : BaseObject
{
    [SerializeField] private SceneAosObject _enterObject;
    [SerializeField] private SceneAosObject _exitObject;
    private void Start()
    {
        IsHoverable = false;
        IsClickable = false;
    }
    private void OnTriggerEnter(Collider col)
    {
        if (_enterObject != null)
            _enterObject.InvokeOnClick();
    }
    private void OnTriggerExit(Collider col)
    {
        API api = FindObjectOfType<API>();
        if (api.MenuTeleport)
        {
            if (_exitObject != null)
                _exitObject.InvokeOnClick();
        }
    }
}
