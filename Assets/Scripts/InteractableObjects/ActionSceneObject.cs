using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSceneObject : BaseObject
{
    [SerializeField] private BaseActionObject _actionObject;
    [SerializeField] private GameObject _imageActionObject;
    public override void EnableObject(bool value)
    {
        if (value)
        {
            _actionObject.CanActivate = true;
            _imageActionObject.SetActive(true);
        }
        else
        {
            _actionObject.CanActivate = false;
            _actionObject.Deactivate();
            _imageActionObject.SetActive(false);
        }
    }
}
