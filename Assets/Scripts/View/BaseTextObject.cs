using UnityEngine;

public abstract class BaseTextObject :MonoBehaviour, IViewObject
{
    public abstract void SetText(string text);
}
