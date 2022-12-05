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

    [SerializeField] protected OutlineCore[] outlineObjects;
    [SerializeField] protected Transform helperPos;
    [SerializeField] protected string helperName;

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
        }
    }
    public virtual void OnHoverIn(InteractHand interactHand)
    {
        if (AOSColliderActivator.Instance.CanTouch || _buttonInPlace)
        {
            if (helperPos != null)
                canvasHelper.ShowTextHelper(helperName, helperPos);
            if (outlineObjects != null)
                foreach (var obj in outlineObjects)
                {
                    obj.enabled = true;
                    obj.OutlineWidth = 3;
                }
        }
    }
    public virtual void OnHoverOut(InteractHand interactHand)
    {
        if (AOSColliderActivator.Instance.CanTouch || _buttonInPlace)
        {
            if (helperPos != null)
                canvasHelper.HidetextHelper();
            if (outlineObjects != null)
                foreach (var obj in outlineObjects)
                {
                    obj.enabled = false;
                    obj.OutlineWidth = 0;
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