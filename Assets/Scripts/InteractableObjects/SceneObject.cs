using AosSdk.Core.PlayerModule.Pointer;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SceneObject : BaseObject
{
    public bool NonAOS;

    [SerializeField] private GameObject[] _highlights;
    public Action<string> HelperTextEvent;
    protected string HelperName;
    private float _emissionValue = 0.1f;
    protected virtual void Start()
    {
        if (!NonAOS)
        {
            EnableObject(false);
            SceneObjectsHolder.Instance.AddSceneObject(this);
        }
    }
    public override void OnHoverIn(InteractHand interactHand)
    {
        if(!NonAOS)
        HelperTextEvent?.Invoke(HelperName);
            EnableHighlight(true);
    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        if (!NonAOS)
            HelperTextEvent?.Invoke(null);
            EnableHighlight(false);
    }
    public override void EnableObject(bool value)
    {
        EnableHighlight(false);
        if (GetComponent<Collider>() != null)
            GetComponent<Collider>().enabled = value;
        if (GetComponent<SpriteRenderer>() != null)
            GetComponent<SpriteRenderer>().enabled = value;
        if (GetComponent<Image>() != null)
            GetComponent<Image>().enabled = value;
    }
    public virtual void SetHelperName(string value) => HelperName = value;
    protected virtual void EnableHighlight(bool value)
    {
        foreach (var visual in _highlights)
        {
            foreach (var mesh in visual.GetComponentsInChildren<Renderer>())
            {
                if (mesh == null)
                    return;
                if (value)
                {
                    mesh.material.EnableKeyword("_EMISSION");
                    mesh.material.SetColor("_EmissionColor", new Color(_emissionValue, _emissionValue, _emissionValue));
                }
                else
                    mesh.material.SetColor("_EmissionColor", Color.black);
            }
        }
    }
}
