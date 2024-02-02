using UnityEngine;

public class DesktopActionObject : BaseActionObject
{
    [SerializeField] protected GameObject Canvas;
    [SerializeField] protected GameObject ActionView;
    public override void Activate()
    {
        if (!CanActivate)
            return;
        if(!Canvas.activeSelf)
        {
            Canvas.SetActive(true);
            Active = true;
        }
        else
            Deactivate();
    }

    public override void ActivateView(bool active) => ActionView.SetActive(active);

    public override void Deactivate()
    {
        Canvas.SetActive(false);
        Active = false;
    }
}
