using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneObject : BaseObject
{
    public bool NonAOS;

    [SerializeField] protected Transform HelperPos;
    [SerializeField] private GameObject[] _highlights;

    protected string HelperName;
    private float _emmisionValue = 0.5f;
    protected virtual void Start()
    {
        if (!NonAOS)
        {
            EnableObject(false);
            AOSColliderActivator.Instance.AddSceneObject(this);
        }
    }
    public override void OnHoverIn(InteractHand interactHand)
    {
            //if (HelperPos != null)
                //InstanceHandler.Instance.HelpTextController.ShowHelperText(HelperPos, HelperName);
            EnableHighlight(true);
    }
    public override void OnHoverOut(InteractHand interactHand)
    {
            //if (HelperPos != null)
            //    CanvasHelper.HidetextHelper();
            EnableHighlight(false);
    }
    public override void EnableObject(bool value)
    {
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
                    mesh.material.SetColor("_EmissionColor", new Color(_emmisionValue, _emmisionValue, _emmisionValue));
                }
                else
                    mesh.material.SetColor("_EmissionColor", Color.black);
            }
        }
    }
}
