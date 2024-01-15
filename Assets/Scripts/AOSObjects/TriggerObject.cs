using System.Collections.Generic;
using System.Linq;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using UnityEngine;
[RequireComponent(typeof(Collider))]

public class TriggerObject : BaseObject
{
    [SerializeField] private SceneAosObject _exitObject;

    protected override void Start()
    {
        base.Start();
        IsHoverable = false;
        IsClickable = false;
    }
    

        private void OnTriggerEnter(Collider col)
        {
            var aosObject = col.GetComponentInParent<AosObjectBase>();
            if (!aosObject)
                return;
        sceneAosObject = GetComponent<SceneAosObject>();
        if (sceneAosObject != null)
        {
            sceneAosObject.InvokeOnClick();
        }
     
    }
    private void OnTriggerExit(Collider col)
    {
        API api = FindObjectOfType<API>();
        if(api.MenuTeleport)
        {
            var aosObject = col.GetComponentInParent<AosObjectBase>();
            if (!aosObject)
                return;
            if (_exitObject != null)
                _exitObject.InvokeOnClick();
            else
                api.Teleport("field");
        }
        if(_exitObject!=null)
        Debug.Log("TriggerExit " + _exitObject.ObjectId);
    }
}
