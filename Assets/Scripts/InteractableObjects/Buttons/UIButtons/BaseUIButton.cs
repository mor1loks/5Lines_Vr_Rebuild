using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class BaseUIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    protected Button Button;
    protected API API;
    protected virtual void Awake()
    {
        Button = GetComponent<Button>();
        if (Button != null)
            Button.onClick.AddListener(() => Click());
    }
    protected virtual void Start()
    {
        API = FindObjectOfType<API>();
    }

    protected virtual void Click()
    {
    }
    public virtual void EnableUIButton(bool value)
    {
        if(Button!=null)
        Button.enabled = value;
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
       
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
       
    }
}
