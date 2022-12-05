using System.Collections.Generic;
using System.Linq;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using UnityEngine;
[RequireComponent(typeof(Collider))]

public class TriggerObject : BaseObject
{
    [SerializeField] private string _locationName;
    [SerializeField] private SceneAosObject _exitObject;
    [SerializeField] private bool _field;

    public override void OnClicked(InteractHand interactHand)
    {
        return;
    }
    public override void OnHoverIn(InteractHand interactHand)
    {
        return;
    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        return;
    }

        private void OnTriggerEnter(Collider col)
        {
            var aosObject = col.GetComponentInParent<AosObjectBase>();
            if (!aosObject)
                return;
        //LocationTextController location = FindObjectOfType<LocationTextController>();
        //location.SetLocation(_locationName);
        sceneAosObject = GetComponent<SceneAosObject>();
        if (sceneAosObject != null && !_field)
        {
            sceneAosObject.InvokeOnClick();
        }
        else if (sceneAosObject != null && _field)
        {
            API api = FindObjectOfType<API>();
 
            api.Teleport("field");
            Debug.Log("TriggerEnter " + sceneAosObject.ObjectId);
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
        Debug.Log("TriggerExit " + _exitObject.ObjectId);

    }
}
