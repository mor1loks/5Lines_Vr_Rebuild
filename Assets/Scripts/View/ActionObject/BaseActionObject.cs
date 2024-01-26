using UnityEngine;

public abstract class BaseActionObject : MonoBehaviour
{
    public bool Active { get; set; }
    public bool CanActivate { get; set; }
    public abstract void Activate();
    public abstract void Deactivate();
}
