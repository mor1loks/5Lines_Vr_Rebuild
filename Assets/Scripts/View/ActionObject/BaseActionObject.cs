using UnityEngine;

public abstract class BaseActionObject : MonoBehaviour
{
    public bool Active;
    public abstract void Activate();
    public abstract void Deactivate();
}
