using UnityEngine;

public abstract class BaseInteractScreen : MonoBehaviour
{
    protected Timer Timer = new Timer();
    public abstract void SetTimerText(string timerText);
    public abstract void SetLocationText(string locationText);
    public abstract void SetReactionText(string reactionText);
    public abstract void SetHelperText(string helperText);
}
