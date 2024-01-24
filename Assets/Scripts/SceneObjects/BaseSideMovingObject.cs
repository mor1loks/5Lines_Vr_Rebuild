using UnityEngine;

public abstract class BaseSideMovingObject : MonoBehaviour
{
    public abstract void SetMoveSide(Vector3 moveVector);
    protected abstract void TryMove();
}
