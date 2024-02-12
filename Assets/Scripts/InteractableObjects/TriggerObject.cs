using System.Collections.Generic;
using System.Linq;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using UnityEngine;
[RequireComponent(typeof(Collider))]

public class TriggerObject : SceneObject
{
    [SerializeField] private SceneAosObject _enterObject;
    protected override void Start()
    {
        base.Start();
        IsHoverable = false;
        IsClickable = false;
    }
    private void OnTriggerEnter(Collider col)
    {
        if (_enterObject != null)
            _enterObject.InvokeOnClick();
    }
}
