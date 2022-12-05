using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOSColliderActivator : MonoBehaviour
{
    public static AOSColliderActivator Instance;
    [SerializeField] private API _api;
    private List<BaseObject> _aosSceneObjects = new List<BaseObject>();
    public bool CanTouch { get; set; } = true;
    private AOSColliderActivator(){}
    private void OnEnable()
    {
        _api.OnShowPlace += OnDeactivateAllColliders;
        _api.OnActivateByName += OnActivateColliders;
    }
    private void OnDisable()
    {
        _api.OnShowPlace -= OnDeactivateAllColliders;
        _api.OnActivateByName -= OnActivateColliders;
    }
    private void Awake()
    {
        if(Instance == null)
        Instance = this;
    }
    public void AddBaseObject(BaseObject obj)
    {
        _aosSceneObjects.Add(obj);
    }

    private void OnActivateColliders(string objectName, string text)
    {
        foreach (var item in _aosSceneObjects)
        {
           if(item.GetAOSName()==objectName)
            {
                item.EnableObject(true);
                item.SetHelperName(text);
            }
        
        }
    }
    private void OnDeactivateAllColliders()
    {
        foreach (var item in _aosSceneObjects)
        {
            item.EnableObject(false);
        }
    }
}
