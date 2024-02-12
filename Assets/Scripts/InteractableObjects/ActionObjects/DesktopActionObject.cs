using UnityEngine;

public class DesktopActionObject : BaseActionObject
{
    [SerializeField] protected GameObject Canvas;
    [SerializeField] protected BaseUIColorChanger ActionView;
    public override void Activate()
    {
        if (!CanActivate)
            return;
        if (!Canvas.activeSelf)
        {
            Canvas.SetActive(true);
            Active = true;
        }
        else
            Deactivate();
    }

    public override void ActivateView(bool active)
    {
        if(ActionView==null)
        {
            Debug.Log(gameObject.name + "   NO ACTION VIEW");
            return;
        }
        if(active)
            ActionView.ChangeColorState(ButtonColorState.Active);
        else 
            ActionView.ChangeColorState(ButtonColorState.Disabled);
    }
    public override void Deactivate()
    {
        Canvas.SetActive(false);
        Active = false;
    }
}
