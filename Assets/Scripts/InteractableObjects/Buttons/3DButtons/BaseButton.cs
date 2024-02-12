using AosSdk.Core.PlayerModule.Pointer;

public class BaseButton : SceneObject
{
    public override void OnHoverIn(InteractHand interactHand)
    {
        base.OnHoverIn(interactHand);
        transform.localScale *= 1.2f;
    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        base.OnHoverOut(interactHand);
        transform.localScale /= 1.2f;
    }
}