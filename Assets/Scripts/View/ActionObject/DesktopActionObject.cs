using UnityEngine;

public class DesktopActionObject : BaseActionObject
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _actionView;
    public override void Activate()
    {
        if (!CanActivate)
            return;
        if(!_canvas.activeSelf)
        {
            _canvas.SetActive(true);
            Active = true;
        }
        else
            Deactivate();
    }

    public override void ActivateView(bool active) => _actionView.SetActive(active);

    public override void Deactivate()
    {
        _canvas.SetActive(false);
        Active = false;
    }
}
