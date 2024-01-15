using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
using AosSdk.ThirdParty.QuickOutline.Scripts;

public class BaseObject : MonoBehaviour, IClickAble, IHoverAble
{

    public bool Button;
    public bool IsHoverable { get; set; } = true;
    public bool IsClickable { get; set; } = true;

    protected CanvasObjectHelperController canvasHelper;
    protected SceneAosObject sceneAosObject;

    [SerializeField] protected bool _buttonInPlace;

    [SerializeField] protected GameObject[] Visuals;
    [SerializeField] protected Transform helperPos;
    [SerializeField] protected string helperName;
    [SerializeField] private bool _door;
    private float _emmisionValue = 0.5f;

    protected virtual void Start()
    {
        canvasHelper = FindObjectOfType<CanvasObjectHelperController>();
        if(!Button)
        {
            var collider = gameObject.GetComponent<Collider>();
            if (collider != null)
                collider.enabled = false;
            AOSColliderActivator.Instance.AddBaseObject(this);
        }
    }

    public virtual void OnClicked(InteractHand interactHand)
    {
        if(AOSColliderActivator.Instance.CanTouch || _buttonInPlace)
        {
            sceneAosObject = GetComponent<SceneAosObject>();
            if (sceneAosObject != null)
            {
                sceneAosObject.InvokeOnClick();
                MovingButtonsController.Instance.ObjectName = sceneAosObject.ObjectId;
            }
            if (_door)
                SoundPlayer.Instance.PlayDoorSound();
        }
    }
    public virtual void OnHoverIn(InteractHand interactHand)
    {
        if (AOSColliderActivator.Instance.CanTouch || _buttonInPlace)
        {
            if (helperPos != null)
                canvasHelper.ShowTextHelper(helperName, helperPos);
            EnableHighlight(true);
        }
    }
    public virtual void OnHoverOut(InteractHand interactHand)
    {
        if (AOSColliderActivator.Instance.CanTouch || _buttonInPlace)
        {
            if (helperPos != null)
                canvasHelper.HidetextHelper();
            EnableHighlight(false);
        }
    }
    protected void EnableHighlight(bool value)
    {
        foreach (var visual in Visuals)
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
    public void SetHelperName(string value)
    {
        helperName = value;
    }
    public string GetAOSName()
    {
        if (GetComponent<AosObjectBase>() != null)
            return GetComponent<AosObjectBase>().ObjectId;
        else return null;
    }
    public void EnableObject(bool value)
    {
        if(GetComponent<Collider>()!=null)
        GetComponent<Collider>().enabled = value;
        if (GetComponent<SpriteRenderer>())
            GetComponent<SpriteRenderer>().enabled = value;
    }
}