using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class BaseUIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    protected Button Button;
    protected API API;
    public Action<bool> HoveredUiEvent;
    protected virtual void Awake()
    {
        Button = GetComponent<Button>();
        if (Button != null)
            Button.onClick.AddListener(() => Click());
    }
    protected virtual void Start()
    {
        API = FindObjectOfType<API>();
        SceneObjectsHolder.Instance.AddBaseUIButton(this);
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
        HoveredUiEvent?.Invoke(false);
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        HoveredUiEvent?.Invoke(true);
    }
}
