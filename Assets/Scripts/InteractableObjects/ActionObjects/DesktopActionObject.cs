using UnityEngine;

public class DesktopActionObject : BaseActionObject
{
    [SerializeField] protected GameObject Canvas;
    public override void Activate()
    {
        base.Activate();
        if (!CanActivate)
            return;
        if (!Canvas.activeSelf)
        {
            Canvas.SetActive(true);
        }
        else
            Deactivate();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        Canvas.SetActive(false);
    }
}
