using UnityEngine;

public abstract class BaseInteractScreen : MonoBehaviour
{
    protected Timer Timer = new Timer();
    public abstract void SetTimerText(string timerText);
    public abstract void SetLocationText(string locationText);
    public abstract void SetHelperText(string helperText);
    public abstract void EnableHelperObject(bool active);
    public abstract void EnableLocationObject(bool active);
    public abstract void EnableTimerObject(bool active);
    public abstract void EnableActionIcons(bool active);
    public abstract void EnableInteractIcons(bool active);
    public abstract void EnableBackButton(bool active);
    public abstract void SetHelperTextPosition(VectorHolder newPos);
    public void EnableAllHelperObjects(bool active)
    {
        EnableLocationObject(active);
        EnableTimerObject(active);
        EnableActionIcons(active);
        EnableInteractIcons(active);
    }
}
