using AosSdk.Core.Utils;
using UnityEngine;
public class AOSRadio : AosObjectBase
{
    [AosEvent(name: "Открыть меню")]
    public event AosEventHandler OnClickObject;
    [SerializeField] private string _location;
    [SerializeField] private bool _side;
    public void InvokeOnClick()
    {
        OnClickObject?.Invoke();
    }
    public string Location()
    {
        return _location;
    }
    public bool Side()
    {
        return _side;
    }
}
