using AosSdk.Core.Utils;
[AosSdk.Core.Utils.AosObject(name: "AosObject")]
public class SceneAosObject : AosObjectBase
{
    [AosEvent(name: "OnClickObject")]
    public event AosEventHandlerWithAttribute OnClickObject;
    public void ActionWithObject(string actionName) => OnClickObject?.Invoke(actionName);
    public void InvokeOnClick() => OnClickObject?.Invoke(ObjectId);
}
